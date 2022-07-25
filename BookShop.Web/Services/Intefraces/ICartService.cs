using BookShop.Shared.Dto;

namespace BookShop.Web.Services.Intefraces
{
    public interface ICartService
    {
        Task<IEnumerable<CartItemDto>> GetCartItems(int userId);
        Task<CartItemDto> AddItemToCart(CartItemAddDto cartItemAddDto);
    }
}
