using Microsoft.AspNetCore.Mvc;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Api.Models;
using BookShop.DTO.DTO;

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
        public async Task<ActionResult<IEnumerable<BookDTO>>> Index()
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
        public async Task<ActionResult<BookCategoryDTO>> BookById(int id)
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
        public async Task<ActionResult> AddNewBook(BookDTO bookDTO, IFormFile uploadedImage)
        {

            await _bookService.AddBookAsync(bookDTO, uploadedImage);
            return Ok(bookDTO);


        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id)
        {

            await _bookService.DeleteBookAsync(id);
            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook(BookDTO bookDTO)
        {

            await _bookService.UpdateBookAsync(bookDTO);
            return Ok();

        }
    }
}
