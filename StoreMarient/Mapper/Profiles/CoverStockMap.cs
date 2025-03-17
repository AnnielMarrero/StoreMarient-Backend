using AutoMapper;
using StoreMarient.Dtos;
using StoreMarient.Entities;


namespace StoreMarient.Mapper.Profiles
{
    public class CoverStockMap : Profile
    {
        public CoverStockMap()
        {
            //CreateMap<Cover, CreateDronDto>()
            //    .ReverseMap();

            //CreateMap<Dron, EditDronDto>()
            //    .ReverseMap();

            CreateMap<CoverStock, CoverStockDto>()
              .ForMember(dto => dto.CoverType, opt => opt.MapFrom(e => e.CoverType.Name))
              .ForMember(dto => dto.Model, opt => opt.MapFrom(e => e.Cover.Model))
              .ForMember(dto => dto.PhoneType, opt => opt.MapFrom(e => e.Cover.PhoneType.Name))
              .ReverseMap();

        }
    }
}
