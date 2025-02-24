using book_finder_api.Models;
using book_finder_api.Services;
using NUnit.Framework;
using System.Linq;

namespace book_finder_api.Tests
{
    public class BookServiceTests
    {
        private BookService _bookService;

        [SetUp]
        public void Setup()
        {
            _bookService = new BookService();
        }

        [Test]
        public void AddBook_ShouldAddBook()
        {
            var book = new Book { Id = 1, Title = "Test Book", Author = "Test Author" };
            _bookService.AddBook(book);

            var result = _bookService.GetAllBooks().FirstOrDefault(b => b.Id == 1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Book", result.Title);
        }

        [Test]
        public void GetBookById_ShouldReturnBook()
        {
            var book = new Book { Id = 1, Title = "Test Book", Author = "Test Author" };
            _bookService.AddBook(book);

            var result = _bookService.GetBookById(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Test Book", result.Title);
        }

        [Test]
        public void GetBooksByTitle_ShouldReturnBooks()
        {
            var book1 = new Book { Id = 1, Title = "Test Book 1", Author = "Test Author" };
            var book2 = new Book { Id = 2, Title = "Another Test Book", Author = "Test Author" };
            _bookService.AddBook(book1);
            _bookService.AddBook(book2);

            var result = _bookService.GetBooksByTitle("Test").ToList();
            Assert.AreEqual(2, result.Count);
        }

        [Test]
        public void GetBooksByAuthor_ShouldReturnBooks()
        {
            var book1 = new Book { Id = 1, Title = "Test Book 1", Author = "Test Author" };
            var book2 = new Book { Id = 2, Title = "Another Test Book", Author = "Another Author" };
            _bookService.AddBook(book1);
            _bookService.AddBook(book2);

            var result = _bookService.GetBooksByAuthor("Test Author").ToList();
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Test Book 1", result[0].Title);
        }
    }
}