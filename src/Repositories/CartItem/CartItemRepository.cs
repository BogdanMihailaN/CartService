using AutoMapper;
using CartService.Domain.Models;
using CartService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CartService.Repositories.CartItem
{
    public class CartItemRepository : ICartItemRepository
    {
        private readonly CartServiceDbContext _context;
        private readonly IMapper _mapper;

        public CartItemRepository(CartServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartItemModel> GetCartItemByIdAsync(int id)
        {
            var cartItem = await _context.CartItems.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var cartItemModel = _mapper.Map<CartItemModel>(cartItem);
            return cartItemModel;
        }

        public async Task<IEnumerable<CartItemModel>> GetAllCartItemsAsync()
        {
            var cartItems = await _context.CartItems.ToListAsync();
            var cartItemModels = _mapper.Map<List<CartItemModel>>(cartItems);
            return cartItemModels;
        }

        public async Task AddCartItemAsync(CartItemModel cartItem)
        {
            var cartItemEntity = _mapper.Map<Domain.Entities.CartItem>(cartItem);
            await _context.CartItems.AddAsync(cartItemEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync(CartItemModel cartItem)
        {
            var cartItemEntity = _mapper.Map<Domain.Entities.CartItem>(cartItem);
            _context.CartItems.Update(cartItemEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartItemAsync(int id)
        {
            var cartItemModel = await GetCartItemByIdAsync(id);
            var cartItem = _mapper.Map<Domain.Entities.CartItem>(cartItemModel);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                await _context.SaveChangesAsync();
            }
        }
    }
}
