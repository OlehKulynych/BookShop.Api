using Microsoft.AspNetCore.Components;
using BookShop.Web.Services.Intefraces;
using BookShop.Shared.Dto;

namespace BookShop.Web.Pages
{
    public class AddBookCategoryBase:ComponentBase
    {
        [Inject]
        public IBookCategoryService _bookCategoryService { get; set; }

        public BookCategoryAddDto BookCategory = new BookCategoryAddDto();

        [Inject]
        public NavigationManager navigationManager { get; set; }
        public string ErrorMessage { get; set; }

        protected async Task AddBookCategory()
        {
            try
            {
                await _bookCategoryService.AddBookCategoryAsync(BookCategory);
                navigationManager.NavigateTo("/BookCategory");
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }

        }
    }
}
