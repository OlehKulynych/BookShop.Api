using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;

namespace BookShop.Api.Repositories.Services
{
    public class BookCategoryService : IBookCategoryService
    {

        private readonly IBookCategoryRepository _bookCategoryRepository;
        public BookCategoryService(IBookCategoryRepository bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task AddBookCategoryAsync(BookCategoryDto bookCategoryDto)
        {
            await _bookCategoryRepository.AddBookCategotyAsync(new BookCategory { Name = bookCategoryDto.Name });

        }

        public async Task<BookCategoryDto> GetBookCategoryByIdAsync(int id)
        {
            var bookCategory = await _bookCategoryRepository.GetCategoryByIdAsync(id);
            return new BookCategoryDto { Id = bookCategory.Id, Name = bookCategory.Name };

        }

        public async Task<IEnumerable<BookCategoryDto>> GetBookCategoriesAsync()
        {
            var bookCategories = await _bookCategoryRepository.GetCategoriesAsync();

            List<BookCategoryDto> bookCategoryDtos = new List<BookCategoryDto>();

            foreach (BookCategory bookCategory in bookCategories)
            {
                var category = new BookCategoryDto
                {
                    Id = bookCategory.Id,
                    Name = bookCategory.Name
                };
                bookCategoryDtos.Add(category);
            }
            return bookCategoryDtos;
        }

        public async Task UpdateBookCategoryAsync(BookCategoryDto bookCategoryDto)
        {
            var bookCategory = await _bookCategoryRepository.GetCategoryByIdAsync(bookCategoryDto.Id);
            bookCategory.Id = bookCategoryDto.Id;
            bookCategory.Name = bookCategoryDto.Name;

            await _bookCategoryRepository.UpdateBookCategoryAsync(bookCategory);
        }

        public async Task DeleteBookCategoryAsync(int id)
        {
            await _bookCategoryRepository.DeleteBookCategoryAsync(id);
        }
    }
}
