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
            try
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }


        [HttpGet]
        [Route("CategoryById")]
        public async Task<ActionResult<BookCategoryDto>> CategoryId(int id)
        {
            try
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }
        [HttpPost]
        public async Task<ActionResult> NewCategory(BookCategoryDto bookCategoryDto)
        {
            try
            {
                await _bookCategoryService.AddBookCategoryAsync(bookCategoryDto);
                return Ok(bookCategoryDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
           
        }


        [HttpDelete]
        public async Task<ActionResult> DeleteBookCategory(int id)
        {
            try
            {
                await _bookCategoryService.DeleteBookCategoryAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBookCategory(BookCategoryDto bookCategoryDto)
        {
            try
            {
                await _bookCategoryService.UpdateBookCategoryAsync(bookCategoryDto);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
