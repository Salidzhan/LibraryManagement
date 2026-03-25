using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Models;

namespace LibraryManagement.Services
{
    public class BookService
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            var existing = books.FirstOrDefault(b => b.Id == book.Id);
            if (existing != null)
            {
                existing.Title = book.Title;
                existing.Genre = book.Genre;
                existing.AuthorId = book.AuthorId;
                existing.AvailableCopies = book.AvailableCopies;
            }
        }

        public void DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                books.Remove(book);
            }
        }

        public List<Book> GetAll()
        {
            return books;
        }
    }
}
