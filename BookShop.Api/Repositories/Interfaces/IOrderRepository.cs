using BookShop.Api.Models;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IOrderRepository
    {
        Task CreateOrderAsync(Order order, List<OrderDetail> orderDetails);
    }
}
