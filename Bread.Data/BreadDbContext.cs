using Bread.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Bread.Data
{
    public class BreadDbContext : DbContext
    {
        // Add migration:
        // dotnet ef -s .\Bread.WebApi -p .\Bread.Data -v migrations add **migration-name**

        // Update database:
        // dotnet ef -s .\Bread.WebApi -p .\Bread.Data -v database update

        public BreadDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Order> Orders { get; set; }
    }
}
