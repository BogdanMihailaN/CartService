using AutoMapper;
using CartService.Domain.Models;
using CartService.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CartService.Repositories.Cart
{
    public class CartRepository : ICartRepository
    {
        private readonly CartServiceDbContext _context;
        private readonly IMapper _mapper;

        public CartRepository(CartServiceDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CartModel> GetCartByIdAsync(int id)
        {
            var cart = await _context.Carts.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
            var cartModel = _mapper.Map<CartModel>(cart);
            return cartModel;
        }

        public async Task<IEnumerable<CartModel>> GetAllCartsAsync()
        {
            var carts = await _context.Carts.ToListAsync();
            var cartModels = _mapper.Map<List<CartModel>>(carts);
            return cartModels;
        }

        public async Task AddCartAsync(CartModel cart)
        {
            var cartEntity = _mapper.Map<Domain.Entities.Cart>(cart);
            await _context.Carts.AddAsync(cartEntity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartAsync(CartModel cart)
        {
            var cartEntity = _mapper.Map<Domain.Entities.Cart>(cart);
            _context.Carts.Update(cartEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartAsync(int id)
        {
            var cartModel = await GetCartByIdAsync(id);
            var cart = _mapper.Map<Domain.Entities.Cart>(cartModel);
            if (cart != null)
            {
                _context.Carts.Remove(cart);
                await _context.SaveChangesAsync();
            }
        }
    }
}
