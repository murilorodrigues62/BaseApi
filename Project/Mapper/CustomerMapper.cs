using Mapster;
using Project.DTO;
using Project.Model;

namespace Project.Mapper
{
    public static class CustomerMapper
    {
        public static void CustomerMapperConfig(this TypeAdapterConfig config)
        {
            config.NewConfig<CustomerDTO, Customer>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Document, src => src.Document)
                .Map(dest => dest.IsActive, src => src.IsActive)
                .IgnoreNonMapped(true);

            config.NewConfig<Customer, CustomerDTO>()
                .Map(dest => dest.Id, src => src.Id)
                .Map(dest => dest.Name, src => src.Name)
                .Map(dest => dest.Document, src => src.Document)
                .Map(dest => dest.IsActive, src => src.IsActive)
                .IgnoreNonMapped(true);
        }
    }
}
