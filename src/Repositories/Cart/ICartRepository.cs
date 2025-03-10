using CartService.Domain.Models;

namespace CartService.Repositories.Cart
{
    public interface ICartRepository
    {
        Task<CartModel> GetCartByIdAsync(int id);
        Task<IEnumerable<CartModel>> GetAllCartsAsync();
        Task AddCartAsync(CartModel user);
        Task UpdateCartAsync(CartModel user);
        Task DeleteCartAsync(int id);
    }
}
