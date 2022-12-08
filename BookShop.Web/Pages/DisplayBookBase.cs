using BookShop.Shared.DTO;
using BookShop.Web.Services;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class DisplayBookBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<BookDto> Books { get; set; }
        [Inject]
        public ICartService cartService { get; set; }

        public string ErrorMessage { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected async Task AddToCart(CartItemAddDto cartItemAddDto)
        {
            try
            {
                if (cartItemAddDto != null)
                {
                    await cartService.AddItemToCart(cartItemAddDto);
                    navigationManager.NavigateTo("/Cart");
                }

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }

    
}
