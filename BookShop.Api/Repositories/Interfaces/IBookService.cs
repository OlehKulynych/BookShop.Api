using BookShop.Shared.DTO;
namespace BookShop.Api.Repositories.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDto>> GetBooksAsync();
        public Task<BookDto> GetBookByIdAsync(int id);
        public Task AddBookAsync(BookAddDto bookAddDto);
        public Task DeleteBookAsync(int id);
        public Task UpdateBookAsync(BookDto bookDto);
        public Task UpdateImageAsync(BookUpdateImageDto bookUpdateImage);
    }
}
