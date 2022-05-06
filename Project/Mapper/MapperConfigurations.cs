using Mapster;

namespace Project.Mapper
{
    public static class MapperConfigurations
    {
        public static TypeAdapterConfig GetConfiguredMappingConfig()
        {
            var config = new TypeAdapterConfig();

            config.CustomerMapperConfig();
            return config;
        }
    }
}
