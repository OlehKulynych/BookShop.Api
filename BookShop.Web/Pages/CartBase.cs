using BookShop.DTO.DTO;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class CartBase: ComponentBase
    {
        [Inject]
        public ICartService cartService { get; set; }

        public IEnumerable<CartItemDTO> cartItems { get; set; }

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
