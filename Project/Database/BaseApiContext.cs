using Project.Database.Mappings;
using Microsoft.EntityFrameworkCore;
using Project.Configurations;
using Project.Model;

namespace Project.Database
{
    public class BaseApiContext : DbContext
    {
        public BaseApiContext(DbContextOptions<BaseApiContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Item { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(AppConfigurations.ServiceName);
            modelBuilder.ApplyConfiguration(new ItemMapping());
            modelBuilder.ApplyConfiguration(new CustomerMapping());
            base.OnModelCreating(modelBuilder);
        }
    }
}
