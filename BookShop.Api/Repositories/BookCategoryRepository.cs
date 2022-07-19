using BookShop.Api.Data;
using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Repositories
{
    public class BookCategoryRepository:IBookCategoryRepository
    {
        private readonly BookShopDbContext _dbContext;

        public BookCategoryRepository(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBookCategotyAsync(BookCategory bookCategory)
        {
            _dbContext.BookCategories.Add(bookCategory);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteBookCategoryAsync(int id)
        {
            var c = await GetCategoryByIdAsync(id);
            _dbContext.BookCategories.Remove(c);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<BookCategory>> GetCategoriesAsync()
        {
            return await _dbContext.BookCategories.ToListAsync();
        }

        public async Task<BookCategory> GetCategoryByIdAsync(int id)
        {
            return await _dbContext.BookCategories.Where(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task UpdateBookCategoryAsync(BookCategory bookCategory)
        {
            _dbContext.BookCategories.Update(bookCategory);
            await _dbContext.SaveChangesAsync();
        }
    }
}
