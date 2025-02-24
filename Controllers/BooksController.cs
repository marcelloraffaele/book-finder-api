using book_finder_api.Models;
using book_finder_api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace book_finder_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            return _bookService.GetAllBooks();
        }

        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            return book;
        }

        [HttpGet("search")]
        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return _bookService.GetBooksByTitle(title);
        }

        [HttpGet("author")]
        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return _bookService.GetBooksByAuthor(author);
        }

        [HttpPost]
        public IActionResult AddBook(Book book)
        {
            _bookService.AddBook(book);
            return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
        }
    }
}