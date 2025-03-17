using AutoMapper;
using StoreMarient.Dtos;
using StoreMarient.Entities;


namespace StoreMarient.Mapper.Profiles
{
    public class MicaMap : Profile
    {
        public MicaMap()
        {
            //CreateMap<Cover, CreateDronDto>()
            //    .ReverseMap();

            //CreateMap<Dron, EditDronDto>()
            //    .ReverseMap();

            CreateMap<Mica, MicaDto>()
              .ForMember(dto => dto.PhoneType, opt => opt.MapFrom(e => e.PhoneType.Name))
              .ReverseMap();

        }
    }
}
