using CartService.Domain.Models;
using CartService.Services.CartItem;
using Microsoft.AspNetCore.Mvc;

namespace CartService.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CartItemController : ControllerBase
    {
        private readonly ICartItemService _cartItemService;

        public CartItemController(ICartItemService cartItemService)
        {
            _cartItemService = cartItemService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCartItemAsync(int id)
        {
            var cartItem = await _cartItemService.GetCartItemByIdAsync(id);
            if (cartItem == null)
            {
                return NotFound();
            }
            return Ok(cartItem);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCartItemsAsync()
        {
            var cartItems = await _cartItemService.GetAllCartItemsAsync();
            return Ok(cartItems);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCartItemAsync([FromBody] CartItemModel cartItemDto)
        {
            var cartItemId = await _cartItemService.CreateCartItemAsync(cartItemDto);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCartItemAsync(int id, [FromBody] CartItemModel cartItemDto)
        {
            await _cartItemService.UpdateCartItemAsync(id, cartItemDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCartItemAsync(int id)
        {
            await _cartItemService.DeleteCartItemAsync(id);
            return NoContent();
        }
    }
}
