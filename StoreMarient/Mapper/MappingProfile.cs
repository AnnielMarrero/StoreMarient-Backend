
using AutoMapper;
using AutoMapper.Internal;
using StoreMarient.Mapper.Profiles;

namespace StoreMarient.Mapper
{
    public static class MappingProfile
    {
        public static void AddAutoMappers(this IServiceCollection services, MapperConfigurationExpression cfg)
        {
            IMapper mapper = new MapperConfiguration(cfg).CreateMapper();
            services.AddSingleton(mapper);
        }
        public static MapperConfigurationExpression AddAutoMapper(this MapperConfigurationExpression cfg)
        {
            cfg.AddProfile<CoverMap>();
            cfg.AddProfile<CoverStockMap>();
            cfg.AddProfile<MicaMap>();
            cfg.AddProfile<PhoneMap>();
            cfg.AddProfile<ProductMap>();
            cfg.Internal().MethodMappingEnabled = false; //for work .net 7, otherwise throw error
            return cfg;
        }
        public static MapperConfigurationExpression CreateExpression()
        {
            return new MapperConfigurationExpression();
        }

    }
}