using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;
using BookShop.Api.Models;
using AutoMapper;

namespace BookShop.Api.Repositories.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IBookCategoryRepository _bookCategoryRepository;
        public BookService(IBookRepository bookRepository, IMapper mapper, IWebHostEnvironment webHostEnvironment, IBookCategoryRepository bookCategoryRepository)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _webHostEnvironment = webHostEnvironment;
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task AddBookAsync(BookAddDto bookAddDto)
        {


            await _bookRepository.AddBookAsync(_mapper.Map<Book>(bookAddDto));


        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            book.BookCategory = await _bookCategoryRepository.GetCategoryByIdAsync(bookDto.BookCategoryId);
            await _bookRepository.UpdateBookAsync(book);

        }
        public async Task UpdateImageAsync(BookUpdateImageDto bookUpdateImage)
        {
            await _bookRepository.UpdateImageAsync(bookUpdateImage.Id, bookUpdateImage.Image);

        }
        public async Task<BookDto> GetBookByIdAsync(int id)
        {
            var book = await _bookRepository.GetBookByIdAsync(id);
            var bookDto = _mapper.Map<BookDto>(book);
            return bookDto;
        }

        public async Task<IEnumerable<BookDto>> GetBooksAsync()
        {
            var books = await _bookRepository.GetBooksAsync();
            var bookDtos = _mapper.Map<IEnumerable<BookDto>>(books);
            return bookDtos;
        }
    }
}
