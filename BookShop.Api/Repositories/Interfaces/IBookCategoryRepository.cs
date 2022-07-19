using BookShop.Api.Models;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IBookCategoryRepository
    {
        Task<BookCategory> GetCategoryByIdAsync(int id);
        Task<IEnumerable<BookCategory>> GetCategoriesAsync();
        Task AddBookCategotyAsync(BookCategory bookCategory);
        Task DeleteBookCategoryAsync(int id);
        Task UpdateBookCategoryAsync(BookCategory bookCategory);
     
    }
}
