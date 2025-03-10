using CartService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartService.Services.CartItem
{
    public interface ICartItemService
    {
        Task<CartItemModel> GetCartItemByIdAsync(int id);
        Task<IEnumerable<CartItemModel>> GetAllCartItemsAsync();
        Task<int> CreateCartItemAsync(CartItemModel user);
        Task UpdateCartItemAsync(int id, CartItemModel userDto);
        Task DeleteCartItemAsync(int id);
    }
}
