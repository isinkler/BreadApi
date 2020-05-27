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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasOne(user => user.Restaurant)
                .WithOne(restaurant => restaurant.Manager)
                .OnDelete(DeleteBehavior.SetNull);
        }

        public DbSet<Address> Addresses { get; set; }        

        public DbSet<KitchenType> KitchenTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderItem> OrderItems { get; set; }

        public DbSet<OrderReview> OrderReviews { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<RedeemedVoucher> RedeemedVouchers { get; set; }

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<RestaurantKitchenType> RestaurantKitchenTypes { get; set; }

        public DbSet<Topping> Toppings { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserAddress> UserAddresses { get; set; }

        public DbSet<Voucher> Vouchers { get; set; }
    }
}
