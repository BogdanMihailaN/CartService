using CartService.Domain.Models;

namespace CartService.Services.Cart
{
    public interface ICartService
    {
        Task<CartModel> GetCartByIdAsync(int id);
        Task<IEnumerable<CartModel>> GetAllCartsAsync();
        Task<int> CreateCartAsync(CartModel user);
        Task UpdateCartAsync(int id, CartModel userDto);
        Task DeleteCartAsync(int id);
    }
}
