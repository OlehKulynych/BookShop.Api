using BookShop.Api.Repositories.Interfaces;
using BookShop.DTO.DTO;
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
        public async Task<ActionResult<IEnumerable<CartItemDTO>>> GetCartItems (int userId)
        {
            try
            {
                var cartItemsDTO = await _cartService.GetCartItemsAsync(userId);

                return Ok(cartItemsDTO);
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{Id:int}")]
        public async Task<ActionResult<CartItemDTO>> GetCartItem(int Id)
        {
            try
            {
                var cartItemDTO = _cartService.GetCartItemAsync(Id);

                return Ok(cartItemDTO);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        
        }
        [HttpPost]
        public async Task<ActionResult<CartItemDTO>> AddItemToCart([FromBody] CartItemAddDTO cartItemAddDTO)
        {
            try
            {
                var cartItemDTO = await _cartService.AddItemToCartAsync(cartItemAddDTO);

                return CreatedAtAction(nameof(GetCartItem), new { id = cartItemDTO.Id }, cartItemDTO);
            }
            catch(Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

    }
}
