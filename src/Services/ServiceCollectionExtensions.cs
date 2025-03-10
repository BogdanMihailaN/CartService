using CartService.Services.Cart;
using CartService.Services.CartItem;
using Microsoft.Extensions.DependencyInjection;

namespace CartService.Services
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddTransient<ICartService, Cart.CartService>();
            services.AddTransient<ICartItemService, CartItemService>();

            return services;
        }
    }
}
