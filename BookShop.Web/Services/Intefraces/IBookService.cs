using BookShop.Shared.DTO;

namespace BookShop.Web.Services.Intefraces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookById(int id);
        Task AddBookCategoryAsync(BookAddDto bookAddDto);

        Task DeleteBookAsync(int id);
        Task UpdateBookAsync(BookDto bookDto);
        Task UpdateImageAsync(BookUpdateImageDto bookUpdateImageDto);
    }
}
