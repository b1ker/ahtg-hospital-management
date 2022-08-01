using HospitalManagement.Domain.Dto;
using MediatR;

namespace HospitalManagement.Business.Queries
{
    public class GetAllHospitals : IRequest<IEnumerable<HospitalData>>
    { }
}

