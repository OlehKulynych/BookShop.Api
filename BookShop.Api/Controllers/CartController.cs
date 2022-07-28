using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly Cart _cart;

        public CartController(ICartService cartService, Cart cart)
        {
            _cartService = cartService;
            _cart = cart;

        }

        //[HttpGet]
        //[Route("{userId}/GetCartItems")]

        //public async Task<ActionResult<IEnumerable<CartItemDto>>> GetCartItems(string userId)
        //{

        //    var cartItemsDto = await _cartService.GetCartItemsAsync(userId);

        //    return Ok(cartItemsDto);

        //}

        //[HttpGet("{Id:int}")]
        //public async Task<ActionResult<CartItemDto>> GetCartItem(int Id)
        //{

        //    var cartItemDto = _cartService.GetCartItemAsync(Id);

        //    return Ok(cartItemDto);


        //}
        //[HttpPost]
        //public async Task<ActionResult<CartItemDto>> AddItemToCart([FromBody] CartItemAddDto cartItemAddDto)
        //{

        //    cartItemAddDto.CartId = _cart.Id;
        //    var cartItemDto = await _cartService.AddItemToCartAsync(cartItemAddDto);

        //    return CreatedAtAction(nameof(GetCartItem), new { id = cartItemDto.Id }, cartItemDto);
        //}

    }
}
