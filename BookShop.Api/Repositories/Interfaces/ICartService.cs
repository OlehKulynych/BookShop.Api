using BookShop.DTO.DTO;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface ICartService
    {
        public Task<IEnumerable<CartItemDTO>> GetCartItemsAsync(int userId);
        Task<CartItemDTO> GetCartItemAsync(int Id);
        Task<CartItemDTO> AddItemToCartAsync(CartItemAddDTO cartItemAddDTO);

    }
}
