using Microsoft.AspNetCore.Components;
using BookShop.Web.Services.Intefraces;
using BookShop.Shared.DTO;
using Microsoft.AspNetCore.Components.Forms;

namespace BookShop.Web.Pages
{
    public class AddBookBase : ComponentBase
    {
        [Inject]
        public IBookService _bookService { get; set; }

        [Inject]
        public IBookCategoryService _bookCategoryService { get; set; }
    
        protected List<BookCategoryDto> bookCategoryDtos = new List<BookCategoryDto>();

        protected string contentString = null;

        public BookAddDto book = new BookAddDto();
        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string ErrorMessage { get; set; }


        protected override async Task OnInitializedAsync()
        {

            try
            {
                bookCategoryDtos = (await _bookCategoryService.GetBookCategoriesAsync()).ToList();
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
        protected async Task AddBook()
        {
            try
            {
                await _bookService.AddBookCategoryAsync(book);
                navigationManager.NavigateTo("/");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
        protected async Task OnInputFileChanged(InputFileChangeEventArgs inputFileChangeEventArgs)
        {
            try
            {
                var img = inputFileChangeEventArgs.File;

                var resizedImg = await img.RequestImageFileAsync(img.ContentType, 640, 480);
                var buffer = new byte[resizedImg.Size];

                await resizedImg.OpenReadStream().ReadAsync(buffer);

                book.ImageUrl = Convert.ToBase64String(buffer);
                book.ImageName = img.Name;
                contentString = $"data:{resizedImg.ContentType};base64,{Convert.ToBase64String(buffer)}";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
           
        }
    }
}
