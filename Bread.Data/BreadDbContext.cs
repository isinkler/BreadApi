using Bread.Common.Enumerations;
using Bread.Data.Models;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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

            modelBuilder
                .Entity<User>()
                .HasIndex(user => user.EmailAddress)
                .IsUnique();

            modelBuilder
                .Entity<Order>()
                .Property(order => order.Status)
                .HasConversion(new EnumToNumberConverter<OrderStatus, int>());
           
            modelBuilder
                .Entity<ProductOrder>()
                .HasOne(productOrder => productOrder.Product)
                .WithMany(product => product.ProductOrders)
                .HasForeignKey(productOrder => productOrder.ProductId);

            modelBuilder
                .Entity<ProductOrder>()
                .HasOne(productOrder => productOrder.Order)
                .WithMany(order => order.ProductOrders)
                .HasForeignKey(productOrder => productOrder.OrderId);
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<KitchenType> KitchenTypes { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<ProductOrder> ProductOrders { get; set; }

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
