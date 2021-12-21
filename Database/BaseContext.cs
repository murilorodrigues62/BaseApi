using BaseApi.Model;
using Microsoft.EntityFrameworkCore;

namespace BaseApi.Database
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> options)
            : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<BaseApi.Model.Item> Item { get; set; }
    }
}
