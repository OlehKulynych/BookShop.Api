using Blazored.LocalStorage;
using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class CartBase : ComponentBase
    {
        [Inject]
        public ICartService cartService { get; set; }

        [Inject]
        public NavigationManager navigationManager { get; set; }

        public IEnumerable<CartItemDto> cartItems { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {               
                cartItems = await cartService.GetCartItems();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task DeleteFromCart(int bookId)
        {
            try
            {
                cartService.DeleteFromCartAsync(bookId);

                navigationManager.NavigateTo("/Cart",true);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }


    }
}
