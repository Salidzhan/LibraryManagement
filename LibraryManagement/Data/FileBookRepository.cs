using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces1;
using System;
using System.Collections.Generic;
using System.Linq;

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

            var book = db.Books.FirstOrDefault(b => b.Id == id);

            if (book == null)
                throw new InvalidOperationException("Book not found.");

            return book;
        }

        public IReadOnlyList<Book> GetAll()
        {
            var db = storage.Load();
            return db.Books.ToList(); // защита от external modification
        }

        public void Save(Book book)
        {
            if (book == null)
                throw new ArgumentNullException(nameof(book));

            if (string.IsNullOrWhiteSpace(book.Title))
                throw new ArgumentException("Book title is required.");

            var db = storage.Load();

            if (book.Id == 0)
            {
                var newBook = new Book(
                    db.NextId++,
                    book.Title,
                    book.Genre,
                    book.AuthorId,
                    book.Copies
                );

                db.Books.Add(newBook);
            }
            else
            {
                var existing = db.Books.FirstOrDefault(b => b.Id == book.Id);

                if (existing == null)
                    throw new InvalidOperationException("Book not found.");

                // update fields (correct approach)
                existing.Title = book.Title;
                existing.Genre = book.Genre;
                existing.AuthorId = book.AuthorId;
                existing.Copies = book.Copies;
                existing.LoanCount = book.LoanCount;
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