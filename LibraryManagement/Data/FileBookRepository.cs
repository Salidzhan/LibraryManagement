using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Data
{
    public class FileBookRepository : IBookRepository
    {
        private readonly FileStorage storage;

        public FileBookRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public Book GetById(int id)
        {
            var db = storage.Load();

            var book = db.Books.FirstOrDefault(p => p.Id == id);

            if (book == null)
                throw new InvalidOperationException("Book not found.");

            return book;
        }

        public IReadOnlyList<Book> GetAll()
        {
            var db = storage.Load();

            return db.Books;
        }

        public void Save(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Book title is missing.", nameof(book));

            var db = storage.Load();

            if (book.Id == 0)
            {
                var newBook = new Book(
                    db.NextId++,
                    book.Title,
                    book.Genre,
                    book.AuthorId,
                    book.AvailableCopies
                    );

                db.Books.Add(newBook);
            }
            else
            {
              
                var index = db.Books.FindIndex(b => b.Id == book.Id);

                if (index == -1)
                    throw new InvalidOperationException("Book not found.");

                db.Books[index] = book;

               
            }
            storage.Save(db);
        }

        public void Delete(int id)
        {
            var db = storage.Load();

            var book = db.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                throw new InvalidOperationException("Book not found.");

            db.Books.Remove(book);

            storage.Save(db);
        }
    }
}
