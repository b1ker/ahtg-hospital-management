using AutoMapper;
using HospitalManagement.Business.Commands;
using HospitalManagement.Domain.Dto;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Infrastructure;
using MediatR;

namespace HospitalManagement.Business.Handlers.Commands
{
    public class AddHospitalHandler : IRequestHandler<AddHospital, bool>
    {
        private readonly HospitalsDb _db;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public AddHospitalHandler(HospitalsDb db, IMapper mapper, ILogger<AddHospitalHandler> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<bool> Handle(AddHospital request, CancellationToken cancellationToken)
        {
            try
            {
                var record = _mapper.Map<HospitalData, Hospital>(request.HospitalData);
                await _db.Hospitals.AddAsync(record);
                await _db.SaveChangesAsync(cancellationToken);

                return true;
            } catch (Exception ex)
            {
                _logger.LogError("There was a problem while adding hospital. Data: {Request}, Exception: {Exception}", request, ex);
                return false;
            }
        }
    }
}

