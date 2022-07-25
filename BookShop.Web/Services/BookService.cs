using BookShop.Shared.Dto;
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

        public async Task<BookDto> GetBookById(int id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"api/Book/{id}");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return default(BookDto);
                    }
                    return await response.Content.ReadFromJsonAsync<BookDto>();
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

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            try
            {
                var response = await _httpClient.GetAsync("api/Book");

                if(response.IsSuccessStatusCode)
                {
                    if(response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<BookDto>();
                    }
                    return await response.Content.ReadFromJsonAsync<IEnumerable<BookDto>>();
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
