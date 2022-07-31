using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace BookShop.Web.Pages
{
    public class EditImageBookBase: ComponentBase
    {
        [Inject]
        public IBookService bookService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public BookDto book = new BookDto();

        public BookUpdateImageDto imagebook = new BookUpdateImageDto();

        [Parameter]
        public int Id { get; set; }

        public string ErrorMessage { get; set; }

        protected string contentString = null;


        protected override async Task OnInitializedAsync()
        {
            book = await bookService.GetBookById(Id);
            contentString = $"data:image/jpeg;base64,{book.ImageUrl}";
        }
        protected async Task UpdateImage()
        {

            try
            {
                imagebook.Id = book.Id;
                imagebook.Image = book.ImageUrl;

                await bookService.UpdateImageAsync(imagebook);
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
                contentString = $"data:{resizedImg.ContentType};base64,{Convert.ToBase64String(buffer)}";
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
