using AutoMapper;
using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;

namespace BookShop.Api.Repositories.Services
{
    public class BookCategoryService : IBookCategoryService
    {

        private readonly IBookCategoryRepository _bookCategoryRepository;
        private readonly IMapper _mapper; 
        public BookCategoryService(IBookCategoryRepository bookCategoryRepository, IMapper mapper)
        {
            _bookCategoryRepository = bookCategoryRepository;
            _mapper = mapper;
        }

        public async Task AddBookCategoryAsync(BookCategoryAddDto bookCategoryAddDto)
        {
            var category = _mapper.Map<BookCategory>(bookCategoryAddDto);
            await _bookCategoryRepository.AddBookCategotyAsync(category);

        }

        public async Task<BookCategoryDto> GetBookCategoryByIdAsync(int id)
        {
            var bookCategory = await _bookCategoryRepository.GetCategoryByIdAsync(id);
            var category = _mapper.Map<BookCategoryDto>(bookCategory);
            return category;

        }

        public async Task<IEnumerable<BookCategoryDto>> GetBookCategoriesAsync()
        {
            var bookCategories = await _bookCategoryRepository.GetCategoriesAsync();
            var bookCategoryDTOs = _mapper.Map<List<BookCategoryDto>>(bookCategories);

            return bookCategoryDTOs;
        }

        public async Task UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto)
        {
            var bookCategory = _mapper.Map<BookCategory>(bookCategoryDto);
            await _bookCategoryRepository.UpdateBookCategoryAsync(bookCategory);
        }

        public async Task DeleteBookCategoryAsync(int id)
        {
            await _bookCategoryRepository.DeleteBookCategoryAsync(id);
        }
    }
}
