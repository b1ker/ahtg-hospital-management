using AutoMapper;
using HospitalManagement.Domain.Dto;
using HospitalManagement.Domain.Entities;
using HospitalManagement.Domain.Models;

namespace HospitalManagement.Mappings
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            AllowNullCollections = true;
            MapEntitiesToDtos();
            MapDtosToEntities();
            MapFormModelsToDto();
        }

        private void MapFormModelsToDto()
        {
            CreateMap<HospitalFormModel, HospitalData>();
            CreateMap<HospitalFormModel, AddressData>();
        }

        private void MapDtosToEntities()
        {
            CreateMap<HospitalData, Hospital>();
            CreateMap<AddressData, Address>();
        }

        private void MapEntitiesToDtos()
        {
            CreateMap<Hospital, HospitalData>();
            CreateMap<Address, AddressData>();
        }
    }
}

