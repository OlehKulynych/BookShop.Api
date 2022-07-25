using BookShop.Shared.Dto;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class DisplayBookBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<BookDto> Books { get; set; }
    }
}
