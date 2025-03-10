using CartService.Domain.Models;
using CartService.Services.Cart;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartAsync(int id)
        {
            var cart = await _cartService.GetCartByIdAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            return Ok(cart);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartsAsync()
        {
            var carts = await _cartService.GetAllCartsAsync();
            return Ok(carts);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartAsync([FromBody] CartModel cartDto)
        {
            var cartId = await _cartService.CreateCartAsync(cartDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartAsync(int id, [FromBody] CartModel cartDto)
        {
            await _cartService.UpdateCartAsync(id, cartDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartAsync(int id)
        {
            await _cartService.DeleteCartAsync(id);
            return NoContent();
        }
    }
}
