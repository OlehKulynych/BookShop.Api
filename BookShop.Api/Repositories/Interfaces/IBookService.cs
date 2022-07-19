using BookShop.DTO.DTO;

namespace BookShop.Api.Repositories.Interfaces
{
    public interface IBookService
    {
        public Task<IEnumerable<BookDTO>> GetBooksAsync();
        public Task<BookDTO> GetBookByIdAsync(int id);
        public Task AddBookAsync(BookDTO bookDTO, IFormFile uploadedImage);
        public Task DeleteBookAsync(int id);
        public Task UpdateBookAsync(BookDTO bookDTO);
    }
}
