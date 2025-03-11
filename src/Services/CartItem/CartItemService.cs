using CartService.Domain.Models;
using CartService.Repositories.CartItem;

namespace CartService.Services.CartItem
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<CartItemModel> GetCartItemByIdAsync(int id)
        {
            var cartItem = await _cartItemRepository.GetCartItemByIdAsync(id);
            return cartItem;
        }

        public async Task<IEnumerable<CartItemModel>> GetAllCartItemsAsync()
        {
            var cartItems = await _cartItemRepository.GetAllCartItemsAsync();
            return cartItems;
        }

        public async Task<int> CreateCartItemAsync(CartItemModel cartItem)
        {
            await _cartItemRepository.AddCartItemAsync(cartItem);
            return cartItem.Id;
        }

        public async Task UpdateCartItemAsync(int id, CartItemModel cartItemDto)
        {
            var cartItem = await _cartItemRepository.GetCartItemByIdAsync(id);
            if (cartItem != null)
            {
                cartItem = cartItemDto;
                cartItem.Id = id;
                await _cartItemRepository.UpdateCartItemAsync(cartItem);
            }
        }

        public async Task DeleteCartItemAsync(int id)
        {
            await _cartItemRepository.DeleteCartItemAsync(id);
        }
    }
}
