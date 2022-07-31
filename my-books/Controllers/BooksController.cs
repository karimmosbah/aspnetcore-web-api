using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Models.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksServices _booksServices;
        public BooksController(BooksServices booksServices)
        {
            _booksServices = booksServices;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _booksServices.GetAllBooks();
            return Ok(allbooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var book = _booksServices.GetBookById(id);
            return Ok(book);
        }

        [HttpPost("Add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _booksServices.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id , [FromBody]BookVM book)
        {
            var updateBook = _booksServices.UpdateBookById(id , book);
            return Ok(updateBook);
        }

        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeleteBookById(int id)
        {
            _booksServices.DeleteBookById(id);
            return Ok();
        }
    }
}
