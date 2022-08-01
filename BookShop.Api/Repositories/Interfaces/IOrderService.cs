using BookShop.Shared.DTO;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IOrderService
    {
        Task CreateOrderAsync(OrderDto orderDto);
    }
}
