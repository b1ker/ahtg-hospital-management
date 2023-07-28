using AutoMapper;
using FluentValidation;
using HospitalManagement.Business.Commands;
using HospitalManagement.Business.Handlers.Commands;
using HospitalManagement.Business.Validators;
using HospitalManagement.Domain.Dto;
using HospitalManagement.Infrastructure;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace HospitalManagement.Tests;

public class Tests
{
    private HospitalsDb _hospitalsDb;
    private IMapper _mapper;
    
    [SetUp]
    public void Setup()
    {
        var _connection = new SqliteConnection("Filename=:memory:");
        _connection.Open();
        var options = new DbContextOptionsBuilder<HospitalsDb>().UseSqlite(_connection)
            .Options;

        var loggerMock = new Mock<ILogger<AddHospitalHandler>>();
        var mapperConfiguration = new MapperConfiguration(cfg =>
        {
            cfg.AddProfile(new Mappings.Mappings()); 
        });
        _mapper = mapperConfiguration.CreateMapper();
        _hospitalsDb= new HospitalsDb(options);
        _hospitalsDb.Database.EnsureCreated();
    }

    [Test]
    public async Task AddingHospitalData_WithCompleteData_CreatesHospital()
    {
        // Arrange
        var hospitalData = new HospitalData
        {
            Name = "Hospital name",
            Description = "Description",
            Address = new AddressData
            {
                AddressLine1 = "Line1",
                ZipCode = "123123",
                State = "Texas",
            }
        };
        var addHospitalRequest = new AddHospital
        {
            HospitalData = hospitalData
        };
        var logger = new Mock<ILogger<AddHospitalHandler>>().Object;
        var handler = new AddHospitalHandler(_hospitalsDb, _mapper, logger, new AddHospitalCommandValidator());

        // Act
        await handler.Handle(addHospitalRequest, new CancellationToken());
        
        // Assert
        Assert.AreEqual(1, _hospitalsDb.Hospitals.Count());
        Assert.AreEqual(hospitalData.Name, _hospitalsDb.Hospitals.First().Name);
        Assert.AreEqual(hospitalData.Description, _hospitalsDb.Hospitals.First().Description);
        Assert.AreEqual(hospitalData.Address.AddressLine1, _hospitalsDb.Hospitals.First().Address.AddressLine1);
    }
    
    [Test]
    public async Task AddingHospitalData_WithIncompleteData_ThrowsValidationException()
    {
        // Arrange
        var hospitalData = new HospitalData
        {
            Name = "Hospital name",
            Description = "Description",
            Address = new AddressData
            {
                AddressLine1 = "Line1",
                ZipCode = "123123",
                State = null,
            }
        };
        var addHospitalRequest = new AddHospital
        {
            HospitalData = hospitalData
        };
        var logger = new Mock<ILogger<AddHospitalHandler>>().Object;
        var handler = new AddHospitalHandler(_hospitalsDb, _mapper, logger, new AddHospitalCommandValidator());

        // Assert
        Assert.ThrowsAsync<ValidationException>(() => handler.Handle(addHospitalRequest, new CancellationToken()));
    }
}