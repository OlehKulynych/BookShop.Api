using BookShop.Shared.Dto;
namespace BookShop.Api.Repositories.Interfaces
{
    public interface ICartService
    {
        public Task<IEnumerable<CartItemDto>> GetCartItemsAsync(int userId);
        Task<CartItemDto> GetCartItemAsync(int Id);
        Task<CartItemDto> AddItemToCartAsync(CartItemAddDto cartItemAddDto);

    }
}
