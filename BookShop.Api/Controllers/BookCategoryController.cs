using BookShop.Api.Data;
using BookShop.Api.Repositories.Interfaces;
using BookShop.DTO.DTO;
using Microsoft.AspNetCore.Mvc;

namespace BookShop.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookCategoryController : Controller
    {
        private readonly IBookCategoryService _bookCategoryService;
        public BookCategoryController(IBookCategoryService bookCategoryService)
        {
            _bookCategoryService = bookCategoryService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookCategoryDTO>>> Index()
        {

            var categories = await _bookCategoryService.GetBookCategoriesAsync();
            if (categories == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(categories);
            }


        }


        [HttpGet]
        [Route("CategoryById")]
        public async Task<ActionResult<BookCategoryDTO>> CategoryId(int id)
        {

            var category = await _bookCategoryService.GetBookCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(category);
            }


        }
        [HttpPost]
        public async Task<ActionResult> NewCategory(BookCategoryDTO bookCategoryDTO)
        {

            await _bookCategoryService.AddBookCategoryAsync(bookCategoryDTO);
            return Ok(bookCategoryDTO);


        }


        [HttpDelete]
        public async Task<ActionResult> DeleteBookCategory(int id)
        {

            await _bookCategoryService.DeleteBookCategoryAsync(id);
            return Ok();

        }

        [HttpPut]
        public async Task<ActionResult> UpdateBookCategory(BookCategoryDTO bookCategoryDTO)
        {

            await _bookCategoryService.UpdateBookCategoryAsync(bookCategoryDTO);
            return Ok();

        }
    }
}
