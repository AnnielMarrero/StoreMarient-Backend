using AutoMapper;
using StoreMarient.Dtos;
using StoreMarient.Entities;


namespace StoreMarient.Mapper.Profiles
{
    public class PhoneMap : Profile
    {
        public PhoneMap()
        {
            //CreateMap<Cover, CreateDronDto>()
            //    .ReverseMap();

            //CreateMap<Dron, EditDronDto>()
            //    .ReverseMap();

            CreateMap<Phone, PhoneDto>()
              .ForMember(dto => dto.Piece, opt => opt.MapFrom(e => e.Piece.Name))
              .ReverseMap();

        }
    }
}
