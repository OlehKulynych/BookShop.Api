using BookShop.DTO.DTO;

namespace BookShop.Web.Services.Intefraces
{
    public interface IBookService
    {
        Task<IEnumerable<BookDTO>> GetBooksAsync();
        Task<BookDTO> GetBookById(int id);
    }
}
