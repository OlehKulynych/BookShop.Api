using BookShop.Api.Repositories.Interfaces;
using BookShop.DTO.DTO;
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

        public async Task AddBookAsync(BookDTO bookDTO, IFormFile uploadedImage)
        {
            if(uploadedImage != null)
            {
                string path = "/img/" + uploadedImage.FileName;

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedImage.CopyToAsync(fileStream);
                }
                await _bookRepository.AddBookAsync(new Book
                {
                    Name = bookDTO.Name,
                    Author = bookDTO.Author,
                    Description = bookDTO.Description,
                    ImageUrl = path,
                    Price = bookDTO.Price,
                    Quantity = bookDTO.Quantity,
                    BookCategoryId = bookDTO.BookCategoryId
                });
            }
           
        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }

        public async Task UpdateBookAsync(BookDTO bookDTO)
        {
            var book = await _bookRepository.GetBookByIdAsync(bookDTO.Id);
            book.Id = bookDTO.Id;
            book.Name = bookDTO.Name;
            book.Author = bookDTO.Author;
            book.Description = bookDTO.Description;
            book.ImageUrl = bookDTO.ImageUrl;
            book.Price = bookDTO.Price;
            book.Quantity = bookDTO.Quantity;
            book.BookCategoryId = bookDTO.BookCategoryId;

            await _bookRepository.UpdateBookAsync(book);

        }

        public async Task<BookDTO> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);

            return new BookDTO
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

        public async Task<IEnumerable<BookDTO>> GetBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            List<BookDTO> bookDTOs = new List<BookDTO>();
            foreach (Book book in books)
            {
                var bookDTO = new BookDTO
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
                bookDTOs.Add(bookDTO);

            }

            return bookDTOs;
        }
    }
}
