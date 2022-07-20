using BookShop.DTO.DTO;
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

        public async Task<CartItemDTO> AddItemToCart(CartItemAddDTO cartItemAddDTO)
        {
            try
            {
                var responce = await _httpClient.PostAsJsonAsync<CartItemAddDTO>("api/Cart",cartItemAddDTO);

                if(responce.IsSuccessStatusCode)
                {
                    if(responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(CartItemDTO);
                    }
                    return await responce.Content.ReadFromJsonAsync<CartItemDTO>();
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

        public async Task<IEnumerable<CartItemDTO>> GetCartItems(int userId)
        {
            try
            {
                var responce = await _httpClient.GetAsync($"api/Cart/{userId}/GetCartItems"); 

                if(responce.IsSuccessStatusCode)
                {
                    if(responce.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<CartItemDTO>();
                    }
                    return await responce.Content.ReadFromJsonAsync<IEnumerable<CartItemDTO>>();
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
