using BookShop.Shared.Dto;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IBookCategoryService
    {
        public Task<IEnumerable<BookCategoryDto>> GetBookCategoriesAsync();

        public Task AddBookCategoryAsync(BookCategoryAddDto bookCategoryAddDto);
        public Task<BookCategoryDto> GetBookCategoryByIdAsync(int id);

        public Task UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto);
        public Task DeleteBookCategoryAsync(int id);
    }
}
