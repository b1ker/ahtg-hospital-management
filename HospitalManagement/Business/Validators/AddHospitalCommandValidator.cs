using FluentValidation;
using HospitalManagement.Business.Commands;

namespace HospitalManagement.Business.Validators;

public class AddHospitalCommandValidator : AbstractValidator<AddHospital>
{
    public AddHospitalCommandValidator()
    {
        RuleFor(c => c.HospitalData.Name).NotEmpty();
        RuleFor(c => c.HospitalData.Description).NotEmpty();
        RuleFor(c => c.HospitalData.Address.AddressLine1).NotEmpty();
        RuleFor(c => c.HospitalData.Address.ZipCode).NotEmpty();
        RuleFor(c => c.HospitalData.Address.State).NotEmpty();
    }
}