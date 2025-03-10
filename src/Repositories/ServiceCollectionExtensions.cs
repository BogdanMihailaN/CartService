using CartService.Repositories.Cart;
using CartService.Repositories.CartItem;
using Microsoft.Extensions.DependencyInjection;

namespace CartService.Repositories
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddTransient<ICartRepository, CartRepository>();
            services.AddTransient<ICartItemRepository, CartItemRepository>();

            return services;
        }
    }
}
