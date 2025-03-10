using CartService.Domain.Models;

namespace CartService.Repositories.CartItem
{
    public interface ICartItemRepository
    {
        Task<CartItemModel> GetCartItemByIdAsync(int id);
        Task<IEnumerable<CartItemModel>> GetAllCartItemsAsync();
        Task AddCartItemAsync(CartItemModel user);
        Task UpdateCartItemAsync(CartItemModel user);
        Task DeleteCartItemAsync(int id);
    }
}
