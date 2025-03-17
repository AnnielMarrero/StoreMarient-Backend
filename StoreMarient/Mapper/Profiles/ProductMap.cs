using AutoMapper;
using StoreMarient.Dtos;
using StoreMarient.Entities;


namespace StoreMarient.Mapper.Profiles
{
    public class ProductMap : Profile
    {
        public ProductMap()
        {
            //CreateMap<Cover, CreateDronDto>()
            //    .ReverseMap();

            //CreateMap<Dron, EditDronDto>()
            //    .ReverseMap();

            CreateMap<Product, ProductDto>()
              .ForMember(dto => dto.Category, opt => opt.MapFrom(e => e.Category.Name))
              .ReverseMap();

        }
    }
}
