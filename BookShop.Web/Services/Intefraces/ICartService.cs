using BookShop.Shared.DTO;

namespace BookShop.Web.Services.Intefraces
{
    public interface ICartService
    {
        Task<IEnumerable<CartItemDto>> GetCartItems();
        Task AddItemToCart(CartItemAddDto cartItemAddDto);
        Task DeleteFromCartAsync(int bookId);
    }
}
