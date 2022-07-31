using BookShop.Api.Data;
using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookShopDbContext _dbContext;

        public BookRepository(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddBookAsync(Book book)
        {
            _dbContext.Books.Add(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _dbContext.Books.Include(c => c.BookCategory).Where(i=> i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksAsync()
        {
            return await _dbContext.Books.Include(c => c.BookCategory).ToListAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _dbContext.Books.Include(c => c.BookCategory).Where(i => i.Id == id).FirstOrDefaultAsync();
            if(book!=null)
            {
                book.isDeleted = true;
                await _dbContext.SaveChangesAsync();
            }
            //_dbContext.Books.Remove(book);
            
        }
        public async Task UpdateBookAsync(Book book)
        {
           
            _dbContext.Books.Update(book);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateImageAsync(int Id, string Image)
        {
           var book = await _dbContext.Books.Where(i => i.Id == Id).FirstOrDefaultAsync();
            book.ImageUrl = Image;
            await _dbContext.SaveChangesAsync();
        }
    }
}
