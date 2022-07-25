using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.Dto;
using BookShop.Api.Models;
using AutoMapper;

namespace BookShop.Api.Repositories.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task AddBookAsync(BookDto bookDto)
        {


            await _bookRepository.AddBookAsync(_mapper.Map<Book>(bookDto));


        }

        public async Task DeleteBookAsync(int id)
        {
            await _bookRepository.DeleteBookAsync(id);
        }

        public async Task UpdateBookAsync(BookDto bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.UpdateBookAsync(book);

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
