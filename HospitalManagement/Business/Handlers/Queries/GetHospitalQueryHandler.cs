using AutoMapper;
using HospitalManagement.Business.Queries;
using HospitalManagement.Domain.Dto;
using HospitalManagement.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagement.Business.Handlers.Queries
{
    public class GetHospitalQueryHandler : IRequestHandler<GetHospital, HospitalData>
    {
        private readonly HospitalsDb _db;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public GetHospitalQueryHandler(HospitalsDb db, IMapper mapper, ILogger<GetHospitalQueryHandler> logger)
        {
            _db = db;
            _mapper = mapper;
            _logger = logger;
        }


        public Task<HospitalData> Handle(GetHospital request, CancellationToken cancellationToken)
        {
            var hospital = 
                _db.Hospitals.
                    Include(h => h.Address).
                    SingleOrDefault(h => h.Id == request.HospitalId)
                ;
            if (hospital == null)
            {
                _logger.LogWarning($"No hotel was found with requested Id: ${request.HospitalId}");
            }
            return Task.FromResult(_mapper.Map<HospitalData>(hospital));
        }
    }
}

