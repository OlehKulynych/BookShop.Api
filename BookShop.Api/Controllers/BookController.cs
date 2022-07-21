﻿using Microsoft.AspNetCore.Mvc;
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
            try
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<BookCategoryDto>> BookById(int id)
        {
            try
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
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpPost]
        public async Task<ActionResult> AddNewBook(BookDto bookDto)
        {
            try
            {
                await _bookService.AddBookAsync(bookDto);
                return Ok(bookDto);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

        }

        [HttpDelete]
        public async Task<ActionResult> DeleteBook (int id)
        {
            try
            {
                await _bookService.DeleteBookAsync(id);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPut]
        public async Task<ActionResult> UpdateBook (BookDto bookDto)
        {
            try
            {
                await _bookService.UpdateBookAsync(bookDto);
                return Ok();
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
