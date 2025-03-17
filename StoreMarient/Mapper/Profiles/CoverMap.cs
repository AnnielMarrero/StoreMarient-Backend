using AutoMapper;
using StoreMarient.Dtos;
using StoreMarient.Entities;


namespace StoreMarient.Mapper.Profiles
{
    public class CoverMap : Profile
    {
        public CoverMap()
        {
            //CreateMap<Cover, CreateDronDto>()
            //    .ReverseMap();

            //CreateMap<Dron, EditDronDto>()
            //    .ReverseMap();

            CreateMap<Cover, CoverDto>()
              .ForMember(dto => dto.PhoneType, opt => opt.MapFrom(e => e.PhoneType.Name))
              .ReverseMap();

        }
    }
}
