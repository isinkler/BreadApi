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
        public BreadDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=BreadDb;Integrated Security=True;MultipleActiveResultSets=true;");
        }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
