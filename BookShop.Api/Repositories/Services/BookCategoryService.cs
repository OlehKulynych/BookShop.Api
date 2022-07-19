using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using BookShop.DTO.DTO;

namespace BookShop.Api.Repositories.Services
{
    public class BookCategoryService : IBookCategoryService
    {

        private readonly IBookCategoryRepository _bookCategoryRepository;
        public BookCategoryService(IBookCategoryRepository bookCategoryRepository)
        {
            _bookCategoryRepository = bookCategoryRepository;
        }

        public async Task AddBookCategoryAsync(BookCategoryDTO bookCategoryDTO)
        {
            await _bookCategoryRepository.AddBookCategotyAsync(new BookCategory { Name = bookCategoryDTO.Name });

        }

        public async Task<BookCategoryDTO> GetBookCategoryByIdAsync(int id)
        {
            var bookCategory = await _bookCategoryRepository.GetCategoryByIdAsync(id);
            return new BookCategoryDTO { Id = bookCategory.Id, Name = bookCategory.Name };

        }

        public async Task<IEnumerable<BookCategoryDTO>> GetBookCategoriesAsync()
        {
            var bookCategories = await _bookCategoryRepository.GetCategoriesAsync();

            List<BookCategoryDTO> bookCategoryDTOs = new List<BookCategoryDTO>();

            foreach (BookCategory bookCategory in bookCategories)
            {
                var category = new BookCategoryDTO
                {
                    Id = bookCategory.Id,
                    Name = bookCategory.Name
                };
                bookCategoryDTOs.Add(category);
            }
            return bookCategoryDTOs;
        }

        public async Task UpdateBookCategoryAsync(BookCategoryDTO bookCategoryDTO)
        {
            var bookCategory = await _bookCategoryRepository.GetCategoryByIdAsync(bookCategoryDTO.Id);
            bookCategory.Id = bookCategoryDTO.Id;
            bookCategory.Name = bookCategoryDTO.Name;

            await _bookCategoryRepository.UpdateBookCategoryAsync(bookCategory);
        }

        public async Task DeleteBookCategoryAsync(int id)
        {
            await _bookCategoryRepository.DeleteBookCategoryAsync(id);
        }
    }
}
