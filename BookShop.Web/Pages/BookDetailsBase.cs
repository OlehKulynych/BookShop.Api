using BookShop.DTO.DTO;
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

        public BookDTO BookDTO { get; set; }
        public string ErrorMessage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                BookDTO = await bookService.GetBookById(Id);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }

        protected async Task AddToCart(CartItemAddDTO cartItemAddDTO)
        {
            try
            {
                var cartItemDTO = await cartService.AddItemToCart(cartItemAddDTO);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
