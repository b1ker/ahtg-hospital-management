using AutoMapper;
using HospitalManagement.Business.Queries;
using HospitalManagement.Domain.Dto;
using HospitalManagement.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Business.Handlers.Queries
{
    public class GetAllHospitalsQueryHandler : IRequestHandler<GetAllHospitals, IEnumerable<HospitalData>>
    {
        private readonly HospitalsDb _db;
        private readonly IMapper _Mapper;

        public GetAllHospitalsQueryHandler(HospitalsDb db, IMapper mapper)
        {
            _db = db;
            _Mapper = mapper;
        }


        public Task<IEnumerable<HospitalData>> Handle(GetAllHospitals request, CancellationToken cancellationToken)
        {
            var hospitals = _db.Hospitals.Include(h => h.Address).AsEnumerable();
            return Task.FromResult(_Mapper.Map<IEnumerable<HospitalData>>(hospitals));
        }
    }
}

