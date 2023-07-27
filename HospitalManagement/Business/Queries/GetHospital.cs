using HospitalManagement.Domain.Dto;
using MediatR;

namespace HospitalManagement.Business.Queries
{
    public class GetHospital : IRequest<HospitalData>
    {
        public Guid HospitalId { get; set; }
    }
}

