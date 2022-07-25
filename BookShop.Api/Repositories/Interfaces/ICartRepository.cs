using BookShop.Api.Models;
using BookShop.Shared.Dto;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface ICartRepository
    {
        Task<CartItem> AddItemToCartAsync(CartItemAddDto cartItemAddDto);
        Task<CartItem> UpdateQuantityAsync(int id, CartItemQuantityDto cartItemQuantityDto);
        Task<CartItem> DeleteItemFromCartAsync(int id);
        Task<CartItem> GetItemByIdAsync(int id);

        Task<IEnumerable<CartItem>> GetItemsByUserIdAsync(int userId);

    }
}
