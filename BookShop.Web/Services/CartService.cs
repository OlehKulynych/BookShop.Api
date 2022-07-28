using Blazored.LocalStorage;
using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using System.Net.Http.Json;

namespace BookShop.Web.Services
{
    public class CartService : ICartService
    {
        private readonly HttpClient _httpClient;
        private readonly IBookService _bookService;
        private readonly ILocalStorageService _localStorageService;
        public CartService(HttpClient httpClient, IBookService bookService, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _bookService = bookService;
            _localStorageService = localStorageService;

        }

        public async Task AddItemToCart(CartItemAddDto cartItemAddDto)
        {
            if (cartItemAddDto != null)
            {
                var cart = await _localStorageService.GetItemAsync<List<CartItemAddDto>>("cart");
                if (cart == null)
                {
                    cart = new List<CartItemAddDto>();

                }
                var item = cart.FirstOrDefault(i => i.BookId == cartItemAddDto.BookId);
                if (item != null)
                {
                    cart.Remove(item);
                    cartItemAddDto.Quantity += item.Quantity;
                }

                cart.Add(cartItemAddDto);
                await _localStorageService.SetItemAsync("cart", cart);

            }
        }

        public async Task DeleteFromCartAsync(int bookId)
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItemAddDto>>("cart");
            var item = cart.FirstOrDefault(i => i.BookId == bookId);
            cart.Remove(item);
            await _localStorageService.SetItemAsync("cart", cart);
        }

        public async Task<IEnumerable<CartItemDto>> GetCartItems()
        {
            var cart = await _localStorageService.GetItemAsync<List<CartItemAddDto>>("cart");

            var cartItemDtos = new List<CartItemDto>();

            foreach (var item in cart)
            {
                var book = await _bookService.GetBookById(item.BookId);

                var cartItem = new CartItemDto
                {
                    BookName = book.Name,
                    Description = book.Description,
                    ImageUrl = book.ImageUrl,
                    Price = book.Price,
                    Quantity = item.Quantity,
                    TotalPrice = item.Quantity * book.Price,
                    BookId = book.Id
                };
                cartItemDtos.Add(cartItem);

            }
            
            return cartItemDtos;

        }
    }
}
