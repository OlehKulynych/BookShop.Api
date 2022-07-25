using BookShop.Shared.Dto;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class BookCategoryBase:ComponentBase
    {
        public IEnumerable<BookCategoryDto> BookCategories;
        [Inject]
        public IBookCategoryService bookCategoryService { get; set; }
        
        public string ErrorMessage { get; set; }
        [Inject]
        public NavigationManager navigationManager { get; set; }

        protected override async Task OnInitializedAsync()
        {
            BookCategories = await bookCategoryService.GetBookCategoriesAsync();
        }

        protected async Task DeleteCategory(int id)
        {
            try
            {
                await bookCategoryService.DeleteBookCategoryAsync(id);
                navigationManager.NavigateTo("/BookCategory",true);
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
        }
    }
}
