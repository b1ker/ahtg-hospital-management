using HospitalManagement.Domain.Dto;
using MediatR;

namespace HospitalManagement.Business.Commands
{
    public class AddHospital : IRequest<bool>
    {
        public HospitalData? HospitalData {get; set;}
    }
}
