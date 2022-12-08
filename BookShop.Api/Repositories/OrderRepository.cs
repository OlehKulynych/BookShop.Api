using BookShop.Api.Data;
using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace BookShop.Api.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly BookShopDbContext _dbContext;
        public OrderRepository(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public async Task CreateOrderAsync(Order order, List<OrderDetail> orderDetails)
        {
            order.OrderTime = DateTime.Now;
            await _dbContext.Orders.AddAsync(order);
            _dbContext.SaveChanges();


            await CreateOrderDetailsAsync(order.Id, orderDetails);
           

        }

        public async Task<IEnumerable<OrderDetail>> GetOrderByUser (string name)
        {
            var orders = await _dbContext.OrderDetails.Include(b => b.Book).Include(o=>o.order).Where(n=>n.order.EmailClient == name).ToListAsync();
            return orders;
        }

        public async Task CreateOrderDetailsAsync(int Id, List<OrderDetail> orderDetails)
        {
            var order = _dbContext.Orders.Where(i => i.Id == Id).FirstOrDefault();

            List<OrderDetail> orderDetailList = new List<OrderDetail>();
            foreach (var item in orderDetails)
            {
                var book = _dbContext.Books.Where(i => i.Id == item.BookId).FirstOrDefault();

                var orderDetail = new OrderDetail()
                {
                    BookId = item.BookId,
                    Price = (uint)(item.Quantity * book.Price),
                    Quantity = item.Quantity,
                    OrderId = order.Id
                };

                book.Quantity--;
                orderDetailList.Add(orderDetail);

            }
            await _dbContext.OrderDetails.AddRangeAsync(orderDetailList);
            _dbContext.SaveChanges();

        }
    }
}
