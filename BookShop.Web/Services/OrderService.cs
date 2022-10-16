using Blazored.LocalStorage;
using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using System.Net.Http.Json;

namespace BookShop.Web.Services
{
    public class OrderService:IOrderService
    {
        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
        public OrderService(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;
        }

        public async Task CreateOrderAsync(OrderDto orderDto)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItemAddDto>>("cart");
            
            if (cart != null)
            {
                orderDto.orderDetailDtos = new List<OrderDetailDto>();
                foreach (var item in cart)
                {
                   
                    orderDto.orderDetailDtos.Add(new OrderDetailDto { BookId = item.BookId, Quantity = item.Quantity });

                }
                await _httpClient.PostAsJsonAsync("api/order/createorder", orderDto);
            }
            else
            {
                var message = "Cart is empty";
                throw new Exception(message);
            }
        }
    }
}
