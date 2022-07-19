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
        public async Task<ActionResult<BookCategoryDTO>> CategoryId(int id)
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
        public async Task<ActionResult> NewCategory(BookCategoryDTO bookCategoryDTO)
        {
            try
            {
                await _bookCategoryService.AddBookCategoryAsync(bookCategoryDTO);
                return Ok(bookCategoryDTO);
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
        public async Task<ActionResult> UpdateBookCategory(BookCategoryDTO bookCategoryDTO)
        {
            try
            {
                await _bookCategoryService.UpdateBookCategoryAsync(bookCategoryDTO);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
