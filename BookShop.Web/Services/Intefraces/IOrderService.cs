using BookShop.Shared.DTO;

namespace BookShop.Web.Services.Intefraces
{
    public interface IOrderService
    {
        public Task CreateOrderAsync(OrderDto orderDto);
    }
}
