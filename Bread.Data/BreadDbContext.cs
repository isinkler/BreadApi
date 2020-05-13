using Bread.Data.Models;

using Microsoft.EntityFrameworkCore;

namespace Bread.Data
{
    public class BreadDbContext : DbContext
    {
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
