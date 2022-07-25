using BookShop.Shared.Dto;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class BookDetailsBase : ComponentBase
    {
        [Parameter]
        public int Id { get; set; }


        [Inject]
        public IBookService bookService { get; set; }

        [Inject]
        public ICartService cartService { get; set; }

        public BookDto BookDto { get; set; }
        public string ErrorMessage { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                BookDto = await bookService.GetBookById(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart(CartItemAddDto cartItemAddDto)
        {
            try
            {
                var cartItemDTO = await cartService.AddItemToCart(cartItemAddDto);
                navigationManager.NavigateTo("/Cart");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
