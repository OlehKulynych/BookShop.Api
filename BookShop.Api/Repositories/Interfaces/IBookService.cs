using BookShop.Shared.Dto;
namespace BookShop.Api.Repositories.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetBooksAsync();
        public Task<BookDto> GetBookByIdAsync(int id);
        public Task AddBookAsync(BookDto bookDto);
        public Task DeleteBookAsync(int id);
        public Task UpdateBookAsync(BookDto bookDto);
    }
}
