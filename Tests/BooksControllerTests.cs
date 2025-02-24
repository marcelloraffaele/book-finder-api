using book_finder_api.Controllers;
using book_finder_api.Models;
using book_finder_api.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Collections.Generic;
using Xunit;

namespace book_finder_api.Tests
{
    public class BooksControllerTests
    {
        private readonly Mock<BookService> _mockBookService;
        private readonly BooksController _controller;

        public BooksControllerTests()
        {
            _mockBookService = new Mock<BookService>();
            _controller = new BooksController(_mockBookService.Object);
        }

        [Fact]
        public void GetAllBooks_ReturnsAllBooks()
        {
            // Arrange
            var books = new List<Book> { new Book { Id = 1, Title = "Test Book" } };
            _mockBookService.Setup(service => service.GetAllBooks()).Returns(books);

            // Act
            var result = _controller.GetAllBooks();

            // Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public void GetBookById_BookExists_ReturnsBook()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Test Book" };
            _mockBookService.Setup(service => service.GetBookById(1)).Returns(book);

            // Act
            var result = _controller.GetBookById(1);

            // Assert
            var actionResult = Assert.IsType<ActionResult<Book>>(result);
            var returnValue = Assert.IsType<Book>(actionResult.Value);
            Assert.Equal(book, returnValue);
        }

        [Fact]
        public void GetBookById_BookDoesNotExist_ReturnsNotFound()
        {
            // Arrange
            _mockBookService.Setup(service => service.GetBookById(1)).Returns((Book)null);

            // Act
            var result = _controller.GetBookById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public void GetBooksByTitle_ReturnsBooks()
        {
            // Arrange
            var books = new List<Book> { new Book { Id = 1, Title = "Test Book" } };
            _mockBookService.Setup(service => service.GetBooksByTitle("Test")).Returns(books);

            // Act
            var result = _controller.GetBooksByTitle("Test");

            // Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public void GetBooksByAuthor_ReturnsBooks()
        {
            // Arrange
            var books = new List<Book> { new Book { Id = 1, Author = "Test Author" } };
            _mockBookService.Setup(service => service.GetBooksByAuthor("Test")).Returns(books);

            // Act
            var result = _controller.GetBooksByAuthor("Test");

            // Assert
            Assert.Equal(books, result);
        }

        [Fact]
        public void AddBook_ValidBook_ReturnsCreatedAtAction()
        {
            // Arrange
            var book = new Book { Id = 1, Title = "Test Book" };

            // Act
            var result = _controller.AddBook(book);

            // Assert
            var actionResult = Assert.IsType<CreatedAtActionResult>(result);
            Assert.Equal(nameof(_controller.GetBookById), actionResult.ActionName);
            Assert.Equal(book.Id, actionResult.RouteValues["id"]);
            Assert.Equal(book, actionResult.Value);
        }
    }
}
