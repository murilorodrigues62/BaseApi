using BaseApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Database
{
    public class BaseApiContext : DbContext
    {
        public BaseApiContext(DbContextOptions<BaseApiContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Item> Item { get; set; }
    }
}
