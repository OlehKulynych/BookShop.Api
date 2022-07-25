using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using System.Net.Http.Json;

namespace BookShop.Web.Services
{
    public class BookCategoryService : IBookCategoryService
    {
        private readonly HttpClient _httpClient;
        public BookCategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<BookCategoryDto>> GetBookCategoriesAsync()
        {
            var response = await _httpClient.GetAsync("api/BookCategory");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return Enumerable.Empty<BookCategoryDto>();
            }
            return await response.Content.ReadFromJsonAsync<IEnumerable<BookCategoryDto>>();

        }

        public async Task AddBookCategoryAsync(BookCategoryAddDto bookCategoryAddDto)
        {
            await _httpClient.PostAsJsonAsync("api/BookCategory/AddCategory", bookCategoryAddDto);

        }

        public async Task<BookCategoryDto> GetBookCategoryByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"api/BookCategory/CategoryById/{id}");

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return default(BookCategoryDto);
            }
            return await response.Content.ReadFromJsonAsync<BookCategoryDto>();
        }

        public async Task UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto)
        {
            await _httpClient.PutAsJsonAsync("api/BookCategory/UpdateBookCategory", bookCategoryDto);
        }

        public async Task DeleteBookCategoryAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/BookCategory/DeleteBookCategory/{id}");
        }
    }
}
