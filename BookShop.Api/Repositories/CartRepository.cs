using BookShop.Api.Data;
using BookShop.Api.Models;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;
using Microsoft.EntityFrameworkCore;

namespace BookShop.Api.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly BookShopDbContext _dbContext;

        public CartRepository(BookShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

   
        private async Task<bool> CartItemExistAsync(string cartId, int bookId)
        {
            return await _dbContext.CartItems.AnyAsync(c => c.CartId == cartId && c.BookId == bookId);
        }

        public async Task<CartItem> AddItemToCartAsync(CartItemAddDto cartItemAddDto)
        {
            //if(await CartItemExistAsync(cartItemAddDto.CartId, cartItemAddDto.BookId)==false)
            //{
    
            var item = new CartItem
            {
                CartId = cartItemAddDto.CartId,
                BookId = cartItemAddDto.BookId,
                Quantity = cartItemAddDto.Quantity
            };

            if (item != null)
            {
                var result = _dbContext.CartItems.Add(item);
                await _dbContext.SaveChangesAsync();
                return await _dbContext.CartItems.Include(c => c.Book).Include(c => c.Cart).Where(c => c.Id == item.Id).SingleOrDefaultAsync();

            }
            //}

            return null;
        }

        public Task<CartItem> DeleteItemFromCartAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<CartItem> GetItemByIdAsync(int id)
        {
            var cart = await _dbContext.CartItems.Include(c => c.Book).Include(c => c.Cart).Where(c => c.Id == id).SingleOrDefaultAsync();
            return cart;

        }

        public async Task<IEnumerable<CartItem>> GetItemsByUserIdAsync(string userId)
        {
            var cart = await _dbContext.CartItems.Include(c => c.Book).Include(c => c.Cart).Where(c => c.Cart.UserId == userId).ToListAsync();

            return cart;

        }

        public Task<CartItem> UpdateQuantityAsync(int id, CartItemQuantityDto cartItemQuantityDto)
        {
            throw new NotImplementedException();
        }
    }
}
