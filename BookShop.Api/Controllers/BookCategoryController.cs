using BookShop.Api.Data;
using BookShop.Api.Repositories.Interfaces;
using BookShop.Shared.DTO;
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
        public async Task<ActionResult<IEnumerable<BookCategoryDto>>> Index()
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
        [Route("CategoryById/{id}")]
        public async Task<ActionResult<BookCategoryDto>> CategoryId(int id)
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
        [Route("AddCategory")]
        public async Task<ActionResult> NewCategory(BookCategoryAddDto bookCategoryAddDto)
        {
            await _bookCategoryService.AddBookCategoryAsync(bookCategoryAddDto);
            return Ok(bookCategoryAddDto);

        }


        [HttpDelete]
        [Route("DeleteBookCategory/{id}")]
        public async Task<ActionResult> DeleteBookCategory(int id)
        {

            await _bookCategoryService.DeleteBookCategoryAsync(id);
            return Ok();

        }

        [HttpPut]
        [Route("UpdateBookCategory")]
        public async Task<ActionResult> UpdateBookCategory(BookCategoryDto bookCategoryDto)
        {

            await _bookCategoryService.UpdateBookCategoryAsync(bookCategoryDto);
            return Ok();
        }
    }
}
