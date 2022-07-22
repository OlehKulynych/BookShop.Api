﻿using BookShop.Shared.DTO;
using BookShop.Web.Services.Intefraces;
using Microsoft.AspNetCore.Components;

namespace BookShop.Web.Pages
{
    public class BooksBase: ComponentBase
    {
        [Inject]
        public IBookService bookService { get; set; }

        public IEnumerable<BookDto> Books { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Books = await bookService.GetBooksAsync();
            
        }
    }
}
