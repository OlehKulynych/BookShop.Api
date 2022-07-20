using BookShop.DTO.DTO;
using BookShop.Web.Services.Intefraces;
using System.Net.Http.Json;

namespace BookShop.Web.Services
{
    public class BookService : IBookService
    {
        private readonly HttpClient _httpClient;
        public BookService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BookDTO> GetBookById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Book/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(BookDTO);
                    }
                    return await response.Content.ReadFromJsonAsync<BookDTO>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception(message);
                        
                }
            }
            catch(Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<BookDTO>> GetBooksAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Book");

                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<BookDTO>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<BookDTO>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
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
