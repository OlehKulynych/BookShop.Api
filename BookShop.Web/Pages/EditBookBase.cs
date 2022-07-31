using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class EditBookBase:ComponentBase
    {
        [Inject]
        public IBookService bookService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public BookDto book = new BookDto();
        [Inject]
        public IBookCategoryService _bookCategoryService { get; set; }

        protected List<BookCategoryDto>? bookCategoryDtos = new List<BookCategoryDto>();
        private string image=null;

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            book = await bookService.GetBookById(Id);
            image = book.ImageUrl;
            bookCategoryDtos = (await _bookCategoryService.GetBookCategoriesAsync()).ToList();
        }
        public string ErrorMessage { get; set; }

        protected async Task UpdateBook()
        {

            try
            {
                book.ImageUrl = image;
                await bookService.UpdateBookAsync(book);
                navigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
