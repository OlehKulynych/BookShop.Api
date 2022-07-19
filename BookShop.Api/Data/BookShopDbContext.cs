using BookShop.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Data
{
    public class BookShopDbContext:DbContext
    {
        public BookShopDbContext(DbContextOptions<BookShopDbContext> options):base(options)
        {

        }

        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<User> Users { get; set; }
    }
}
