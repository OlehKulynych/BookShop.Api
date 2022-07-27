using AutoMapper;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;

namespace BookShop.Api.Repositories.Services
{
    public class CartService : ICartService
    {
        //private readonly ICartRepository _cartRepository;
        //private readonly IBookRepository _bookRepository;
        //private readonly IMapper _mapper;
        //public CartService(ICartRepository cartRepository, IBookRepository bookRepository, IMapper mapper)
        //{
        //    _mapper = mapper;
        //    _cartRepository = cartRepository;
        //    _bookRepository = bookRepository;
        //}

        //public async Task<IEnumerable<CartItemDto>> GetCartItemsAsync(string userId)
        //{
        //    var cartItems = await _cartRepository.GetItemsByUserIdAsync(userId);

        //    var cartItemDtos = _mapper.Map<IEnumerable<CartItemDto>>(cartItems);

        //    return cartItemDtos;
        //}

        //public async Task<CartItemDto> GetCartItemAsync(int Id)
        //{

        //    var cartItem = await _cartRepository.GetItemByIdAsync(Id);

        //    return _mapper.Map<CartItemDto>(cartItem);


        //}

        //public async Task<CartItemDto> AddItemToCartAsync(CartItemAddDto cartItemAddDto)
        //{
        //    var cartItem = await _cartRepository.AddItemToCartAsync(cartItemAddDto);
        //    return _mapper.Map<CartItemDto>(cartItem);
        //}
    }
}
