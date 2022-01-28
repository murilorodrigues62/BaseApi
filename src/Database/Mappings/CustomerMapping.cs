using BaseApi.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BaseApi.Database.Mappings
{
    public class CustomerMapping : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable(nameof(Customer));

            builder.HasIndex(x => new
            {
                x.Document             
            });

            builder.Property(x => x.Name)
                .IsRequired();

            builder.Property(x => x.Document)
               .IsRequired();
        }
    }
}
