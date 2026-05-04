using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces1;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Services
{
    public class BookService
    {
        private readonly IBookRepository bookRepo;

        public BookService(IBookRepository bookRepo)
        {
            this.bookRepo = bookRepo;
        }
        public void AddBook(string title, string genre, int authorId, int copies)
        {
            var book = new Book(
                0,
               title,
               genre,
               authorId,
               copies
               );

            bookRepo.Save(book);
        }
        public void UpdateBook(int id, string title, string genre, int authorId, int copies)
        {
            var book = bookRepo.GetById(id);

            book.Title = title;
            book.Genre = genre;
            book.AuthorId = authorId;
            book.AvailableCopies = copies;

            bookRepo.Save(book);

        }

        public void DeleteBook(int id)
        {

            bookRepo.Delete(id);
        }

        public IReadOnlyList<Book> GetAllBooks()
        {
            return bookRepo.GetAll();
        }
    }
}
