using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class CartBase: ComponentBase
    {
        [Inject]
        public ICartService cartService { get; set; }

        public IEnumerable<CartItemDto> cartItems { get; set; }

        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                cartItems = await cartService.GetCartItems(1); //userId
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
