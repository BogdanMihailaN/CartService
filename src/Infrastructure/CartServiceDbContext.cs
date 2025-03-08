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

            // Configurare relație între Cart și CartItem (uno la mulți)
            modelBuilder.Entity<Cart>()
                .HasMany(c => c.Items)
                .WithOne(ci => ci.Cart)  // Legătura inversă de la CartItem la Cart
                .HasForeignKey(ci => ci.CartId)  // Cheia străină în CartItem
                .OnDelete(DeleteBehavior.Cascade);  // Ștergere în cascadă a articolelor când se șterge un coș

            // Configurare pentru entitatea CartItem
            modelBuilder.Entity<CartItem>()
                .Property(ci => ci.TotalPrice)
                .HasComputedColumnSql("[Price] * [Quantity]");  // TotalPrice calculat automat pe baza prețului și cantității

            modelBuilder.Entity<CartItem>()
                .Property(ci => ci.TotalDiscount)
                .HasComputedColumnSql("[Discount] * [Quantity]");  // TotalDiscount calculat automat pe baza discount-ului și cantității

            // Configurare pentru entitatea Cart
            modelBuilder.Entity<Cart>()
                .Property(c => c.TotalPrice)
                .HasDefaultValue(0.0M);  // Poți seta o valoare implicită pentru TotalPrice dacă nu este calculat altfel

            modelBuilder.Entity<Cart>()
                .Property(c => c.TotalDiscount)
                .HasDefaultValue(0.0M);  // Poți seta o valoare implicită pentru TotalDiscount dacă nu este calculat altfel

            // Configurare pentru entitatea CartItem
            modelBuilder.Entity<CartItem>()
                .HasIndex(ci => ci.ProductId);  // Creare index pe ProductId pentru a îmbunătăți performanța interogărilor

            // Seed data în Cart
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

            // Seed data în CartItem
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
