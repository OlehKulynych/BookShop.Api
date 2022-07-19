using BookShop.Api.Models;
using BookShop.DTO.DTO;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<CartItem> AddItemToCartAsync(CartItemAddDTO cartItemAddDto);
        Task<CartItem> UpdateQuantityAsync(int id, CartItemQuantityDTO cartItemQuantityDTO);
        Task<CartItem> DeleteItemFromCartAsync(int id);
        Task<CartItem> GetItemByIdAsync(int id);

        Task<IEnumerable<CartItem>> GetItemsByUserIdAsync(int userId);

    }
}
