using BookShop.Shared.Dto;
using BookShop.Web.Services.Intefraces;
using System.Net.Http.Json;

namespace BookShop.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        public CartService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CartItemDto> AddItemToCart(CartItemAddDto cartItemAddDto)
        {
            try
            {
                var responce = await _httpClient.PostAsJsonAsync<CartItemAddDto>("api/Cart",cartItemAddDto);

                if(responce.IsSuccessStatusCode)
                {
                    if(responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartItemDto);
                    }
                    return await responce.Content.ReadFromJsonAsync<CartItemDto>();
                }
                else
                {
                    var message = await responce.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItems(int userId)
        {
            try
            {
                var responce = await _httpClient.GetAsync($"api/Cart/{userId}/GetCartItems"); 

                if(responce.IsSuccessStatusCode)
                {
                    if(responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemDto>();
                    }
                    return await responce.Content.ReadFromJsonAsync<IEnumerable<CartItemDto>>();
                }
                else
                {
                    var message = await responce.Content.ReadAsStringAsync();
                    throw new Exception(message);
                }
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
