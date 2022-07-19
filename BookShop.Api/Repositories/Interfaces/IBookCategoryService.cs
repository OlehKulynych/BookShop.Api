using BookShop.DTO.DTO;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IBookCategoryService
    {
        public Task<IEnumerable<BookCategoryDTO>> GetBookCategoriesAsync();

        public Task AddBookCategoryAsync(BookCategoryDTO bookCategoryDTO);
        public Task<BookCategoryDTO> GetBookCategoryByIdAsync(int id);

        public Task UpdateBookCategoryAsync(BookCategoryDTO bookCategoryDTO);
        public Task DeleteBookCategoryAsync(int id);
    }
}
