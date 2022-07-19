using BookShop.Api.Models;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetBooksAsync();

        Task<Book> GetBookByIdAsync(int id);
        Task AddBookAsync(Book book);
        Task DeleteBookAsync(int id);
        Task UpdateBookAsync(Book book);
    }
}
