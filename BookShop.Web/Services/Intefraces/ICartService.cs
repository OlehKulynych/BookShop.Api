using BookShop.DTO.DTO;

namespace BookShop.Web.Services.Intefraces
{
    public interface ICartService
    {
        Task<IEnumerable<CartItemDTO>> GetCartItems(int userId);
        Task<CartItemDTO> AddItemToCart(CartItemAddDTO cartItemAddDTO);
    }
}
