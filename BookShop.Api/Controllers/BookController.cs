using Microsoft.AspNetCore.Mvc;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Api.Models;
using BookShop.Shared.DTO;

namespace BookShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> Index()
        {

            var books = await _bookService.GetBooksAsync();
            if (books == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(books);
            }


        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookCategoryDto>> BookById(int id)
        {

            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(book);
            }


        }

        [HttpPost]
        public async Task<ActionResult> AddNewBook(BookDto bookDto)
        {

            await _bookService.AddBookAsync(bookDto);
            return Ok(bookDto);

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id)
        {

            await _bookService.DeleteBookAsync(id);
            return Ok();

        }

        [HttpPut]

        public async Task<ActionResult> UpdateBook (BookDto bookDto)
        {

                await _bookService.UpdateBookAsync(bookDto);
                return Ok();

        }
    }
}
