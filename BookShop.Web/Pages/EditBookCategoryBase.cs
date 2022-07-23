using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class EditBookCategoryBase: ComponentBase
    {
        [Inject]
        public IBookCategoryService bookCategoryService { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        public BookCategoryDto BookCategory = new BookCategoryDto();

        [Parameter]
        public int Id { get; set; }
        protected override async Task OnInitializedAsync()
        {
            BookCategory = await bookCategoryService.GetBookCategoryByIdAsync(Id);
        }
        public string ErrorMessage { get; set; }

        protected async Task UpdateCategory()
        {
            
            try
            {
                await bookCategoryService.UpdateBookCategoryAsync(BookCategory);
                navigationManager.NavigateTo("/BookCategory");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }




    }
}
