using AutoMapper;
using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;

namespace BookShop.Api.Repositories.Services
{
    public class OrderService: IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public OrderService(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }

        public async Task CreateOrderAsync(OrderDto orderDto)
        {
            var order = _mapper.Map<Order>(orderDto);

            var orderDetailDtos = orderDto.orderDetailDtos;
            var orderDetails = new List<OrderDetail>();
            
            foreach(var item in orderDetailDtos)
            {
                orderDetails.Add(_mapper.Map<OrderDetail>(item));
            }

            await _orderRepository.CreateOrderAsync(order, orderDetails);
        }

        public async Task<IEnumerable<OrderUserDto>> GetOrderByUser(string name)
        {
            var orders = await _orderRepository.GetOrderByUser(name);
            var orderDtos = _mapper.Map<IEnumerable<OrderUserDto>>(orders);
            return orderDtos;
        }
    }
}
