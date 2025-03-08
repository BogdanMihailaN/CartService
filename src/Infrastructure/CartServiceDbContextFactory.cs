using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CartService.Infrastructure
{
    public class CartServiceDbContextFactory : IDesignTimeDbContextFactory<CartServiceDbContext>
    {
        public CartServiceDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CartServiceDbContext>();

            optionsBuilder.UseSqlServer("Server=localhost;Database=CartServiceDb;TrustServerCertificate=True;Integrated Security=True;");

            return new CartServiceDbContext(optionsBuilder.Options);
        }
    }
}
