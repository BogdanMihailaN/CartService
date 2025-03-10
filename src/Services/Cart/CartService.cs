using CartService.Domain.Models;
using CartService.Repositories.Cart;

namespace CartService.Services.Cart
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<CartModel> GetCartByIdAsync(int id)
        {
            var cart = await _cartRepository.GetCartByIdAsync(id);
            return cart;
        }

        public async Task<IEnumerable<CartModel>> GetAllCartsAsync()
        {
            var carts = await _cartRepository.GetAllCartsAsync();
            return carts;
        }

        public async Task<int> CreateCartAsync(CartModel cart)
        {
            await _cartRepository.AddCartAsync(cart);
            return cart.Id;
        }

        public async Task UpdateCartAsync(int id, CartModel cartDto)
        {
            var cart = await _cartRepository.GetCartByIdAsync(id);
            if (cart != null)
            {
                cart = cartDto;
                await _cartRepository.UpdateCartAsync(cart);
            }
        }

        public async Task DeleteCartAsync(int id)
        {
            await _cartRepository.DeleteCartAsync(id);
        }
    }
}
