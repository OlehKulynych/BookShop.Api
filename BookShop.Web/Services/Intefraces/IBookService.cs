using BookShop.Shared.DTO;

namespace BookShop.Web.Services.Intefraces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDto>> GetBooksAsync();
        Task<BookDto> GetBookById(int id);
    }
}
