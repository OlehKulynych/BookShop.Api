using BookShop.Api.Repositories.Interfaces;
using BookShop.DTO.DTO;

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

        public async Task<IEnumerable<CartItemDTO>> GetCartItemsAsync(int userId)
        {
            List<CartItemDTO> cartItemDTOs = new List<CartItemDTO>();
            var cartItems = await _cartRepository.GetItemsByUserIdAsync(userId);
            foreach (var cartItem in cartItems)
            {

                cartItemDTOs.Add(new CartItemDTO { 
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

        public async Task<CartItemDTO> GetCartItemAsync(int Id)
        {
     
            var cartItem = await _cartRepository.GetItemByIdAsync(Id);

            return new CartItemDTO {
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

        public async Task<CartItemDTO> AddItemToCartAsync(CartItemAddDTO cartItemAddDTO)
        {
            var cartItem =  await _cartRepository.AddItemToCartAsync(cartItemAddDTO);
            return new CartItemDTO
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
