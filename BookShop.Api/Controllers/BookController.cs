using Microsoft.AspNetCore.Mvc;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Api.Models;
using BookShop.Shared.DTO;
using Microsoft.AspNetCore.Authorization;

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
        [Route("addbook")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> AddNewBook(BookAddDto bookAddDto)
        {

            await _bookService.AddBookAsync(bookAddDto);
            return Ok(bookAddDto);

        }

        [HttpDelete]
        [Route("DeleteBook/{id}")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> DeleteBook(int id)
        {

            await _bookService.DeleteBookAsync(id);
            return Ok();

        }

        [HttpPut]
        [Route("UpdateBook")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> UpdateBook (BookDto bookDto)
        {

                await _bookService.UpdateBookAsync(bookDto);
                return Ok();

        }

        [HttpPut]
        [Route("UpdateImage")]
        [Authorize(Roles = "ADMIN")]
        public async Task<ActionResult> UpdateImage(BookUpdateImageDto bookUpdateImage)
        {

            await _bookService.UpdateImageAsync(bookUpdateImage);
            return Ok();

        }
    }
}
