using book_finder_api.Models;
using System.Collections.Generic;
using System.Linq;

namespace book_finder_api.Services
{
    public class BookService
    {
        private readonly List<Book> _books = new List<Book>();

        public IEnumerable<Book> GetAllBooks()
        {
            return _books;
        }

        public Book GetBookById(int id)
        {
            return _books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetBooksByTitle(string title)
        {
            return _books.Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase));
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return _books.Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
        }

        public void AddBook(Book book)
        {
            _books.Add(book);
        }
    }
}