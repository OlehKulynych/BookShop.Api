using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;
using BookShop.Api.Models;

namespace BookShop.Api.Repositories.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IWebHostEnvironment? _appEnvironment;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task AddBookAsync(BookDto bookDto)
        {


            await _bookRepository.AddBookAsync(new Book
            {
                Name = bookDto.Name,
                Author = bookDto.Author,
                Description = bookDto.Description,
                ImageUrl = bookDto.ImageUrl,
                Price = bookDto.Price,
                Quantity = bookDto.Quantity,
                BookCategoryId = bookDto.BookCategoryId
            });


        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookDto.Id);
            book.Id = bookDto.Id;
            book.Name = bookDto.Name;
            book.Author = bookDto.Author;
            book.Description = bookDto.Description;
            book.ImageUrl = bookDto.ImageUrl;
            book.Price = bookDto.Price;
            book.Quantity = bookDto.Quantity;
            book.BookCategoryId = bookDto.BookCategoryId;

            await _bookRepository.UpdateBookAsync(book);

        }

        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            return new BookDto
            {
                Id = book.Id,
                Name = book.Name,
                Author = book.Author,
                Description = book.Description,
                ImageUrl = book.ImageUrl,
                Price = book.Price,
                Quantity = book.Quantity,
                BookCategoryName = book.BookCategory.Name
            };
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            List<BookDto> bookDtos = new List<BookDto>();
            foreach (Book book in books)
            {
                var bookDTO = new BookDto
                {
                    Id = book.Id,
                    Name = book.Name,
                    Author = book.Author,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    Price = book.Price,
                    Quantity = book.Quantity,
                    BookCategoryName = book.BookCategory.Name
                };
                bookDtos.Add(bookDTO);

            }

            return bookDtos;
        }
    }
}
