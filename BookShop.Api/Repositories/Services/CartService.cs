using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;

namespace BookShop.Api.Repositories.Services
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly IBookRepository _bookRepository;

        public CartService(ICartRepository cartRepository, IBookRepository bookRepository)
        {
            _cartRepository = cartRepository;
            _bookRepository = bookRepository;
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItemsAsync(int userId)
        {
            List<CartItemDto> cartItemDTOs = new List<CartItemDto>();
            var cartItems = await _cartRepository.GetItemsByUserIdAsync(userId);
            foreach (var cartItem in cartItems)
            {

                cartItemDTOs.Add(new CartItemDto { 
                    Id = cartItem.Id, 
                    BookId = cartItem.BookId, 
                    BookName = cartItem.Book.Name, 
                    CartId = cartItem.CartId, 
                    Description = cartItem.Book.Description, 
                    ImageUrl = cartItem.Book.ImageUrl, 
                    Price = cartItem.Book.Price,
                    Quantity = cartItem.Quantity,
                    TotalPrice = cartItem.Quantity * cartItem.Book.Price

                });

            }
            return cartItemDTOs;
        }

        public async Task<CartItemDto> GetCartItemAsync(int Id)
        {
     
            var cartItem = await _cartRepository.GetItemByIdAsync(Id);

            return new CartItemDto {
                Id = cartItem.Id,
                BookId = cartItem.BookId,
                BookName = cartItem.Book.Name,
                CartId = cartItem.CartId,
                Description = cartItem.Book.Description,
                ImageUrl = cartItem.Book.ImageUrl,
                Price = cartItem.Book.Price,
                Quantity = cartItem.Quantity,
                TotalPrice = cartItem.Quantity * cartItem.Book.Price
            };

        }

        public async Task<CartItemDto> AddItemToCartAsync(CartItemAddDto cartItemAddDto)
        {
            var cartItem =  await _cartRepository.AddItemToCartAsync(cartItemAddDto);
            return new CartItemDto
            {
                Id = cartItem.Id,
                BookId = cartItem.BookId,
                BookName = cartItem.Book.Name,
                CartId = cartItem.CartId,
                Description = cartItem.Book.Description,
                ImageUrl = cartItem.Book.ImageUrl,
                Price = cartItem.Book.Price,
                Quantity = cartItem.Quantity,
                TotalPrice = cartItem.Quantity * cartItem.Book.Price
            };
        }
    }
}
