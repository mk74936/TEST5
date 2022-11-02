using Microsoft.EntityFrameworkCore;
using TEST5.API.Models.Domain;

namespace TEST5.API.Data
{
    public class TEST5DbContext:DbContext
    {
        public TEST5DbContext(DbContextOptions<TEST5DbContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

    }
}
