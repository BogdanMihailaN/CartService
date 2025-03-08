using CartService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CartService.Infrastructure
{
    public class CartServiceDbContext : DbContext
    {
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }

        public CartServiceDbContext(DbContextOptions<CartServiceDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne()
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CartItem>()
                .Property(ci => ci.TotalPrice)
                .HasComputedColumnSql("[Price] * [Quantity]");

            // Seed data in Cart and CartItem tables
            modelBuilder.Entity<Cart>().HasData(
                new Cart
                {
                    Id = 1,
                    UserId = 1,
                    TotalPrice = 0.0M,
                    TotalDiscount = 0.0M,
                    ShippingCost = 5.0M,
                    TaxAmount = 0.0M,
                    CreatedAt = new DateTime(2025, 3, 8),
                    UpdatedAt = new DateTime(2025, 3, 8)
                });

            modelBuilder.Entity<CartItem>().HasData(
                new CartItem
                {
                    Id = 1,
                    CartId = 1,
                    ProductId = 2,
                    ProductName = "Product 1",
                    ProductImageUrl = "https://example.com/product1.jpg",
                    Price = 10.0M,
                    Quantity = 1,
                    TotalPrice = 10.0M,
                    Discount = 0.0M,
                    TotalDiscount = 0.0M
                },
                new CartItem
                {
                    Id = 2,
                    CartId = 1,
                    ProductId = 3,
                    ProductName = "Product 2",
                    ProductImageUrl = "https://example.com/product2.jpg",
                    Price = 20.0M,
                    Quantity = 2,
                    TotalPrice = 40.0M,
                    Discount = 5.0M,
                    TotalDiscount = 10.0M
                });
        }
    }
}
