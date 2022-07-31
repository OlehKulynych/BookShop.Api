using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class BooksBase: ComponentBase
    {
        [Inject]
        public IBookService bookService { get; set; }

        public IEnumerable<BookDto> Books { get; set; }
        public string ErrorMessage { get; set; }
        protected override async Task OnInitializedAsync()
        {
            try
            {
                Books = await bookService.GetBooksAsync();
                //throw new Exception(Books.ToList()[0].ImageUrl);

            }
            catch(Exception ex)
            {
                ErrorMessage = ex.Message;
            }
       
            
        }

    }
}
