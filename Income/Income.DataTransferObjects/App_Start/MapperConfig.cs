using AutoMapper;
using Income.DataTransferObjects.MappingEngine;

namespace Income.DataTransferObjects.App_Start
{
    public class MapperConfig
    {
        public static void Configure()
        {
            MapperConfiguration config = new MapperConfiguration(cfg => RegisterProfiles(cfg));
            config.AssertConfigurationIsValid();
            config.CompileMappings();

            ModelMapper.Initialize(config.CreateMapper());
        }

        private static void RegisterProfiles(IMapperConfigurationExpression config)
        {
            config.AddProfile<MappingProfile>();
        }
    }
}
