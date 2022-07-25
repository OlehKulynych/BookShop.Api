using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        [HttpGet]
        [Route("{userId}/GetCartItems")]

        public async Task<ActionResult<IEnumerable<CartItemDto>>> GetCartItems (int userId)
        {

            var cartItemsDto = await _cartService.GetCartItemsAsync(userId);

            return Ok(cartItemsDto);

        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<CartItemDto>> GetCartItem(int Id)
        {

            var cartItemDto = _cartService.GetCartItemAsync(Id);

            return Ok(cartItemDto);


        }
        [HttpPost]
        public async Task<ActionResult<CartItemDto>> AddItemToCart([FromBody] CartItemAddDto cartItemAddDto)
        {


               var cartItemDto = await _cartService.AddItemToCartAsync(cartItemAddDto);

                return CreatedAtAction(nameof(GetCartItem), new { id = cartItemDto.Id }, cartItemDto);
        }

    }
}
