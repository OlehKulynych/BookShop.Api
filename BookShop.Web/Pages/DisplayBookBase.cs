using BookShop.DTO.DTO;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class DisplayBookBase: ComponentBase
    {
        [Parameter]
        public IEnumerable<BookDTO> Books { get; set; }
    }
}
