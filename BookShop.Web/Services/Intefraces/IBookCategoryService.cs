using BookShop.Shared.DTO;

namespace BookShop.Web.Services.Intefraces
{
    public interface IBookCategoryService
    {
        Task<IEnumerable<BookCategoryDto>> GetBookCategoriesAsync();
        Task<BookCategoryDto> GetBookCategoryByIdAsync(int id);
        Task UpdateBookCategoryAsync(BookCategoryDto bookCategoryAddDto);
        Task AddBookCategoryAsync(BookCategoryAddDto bookCategoryAddDto);
        Task DeleteBookCategoryAsync(int id);
    }
}
