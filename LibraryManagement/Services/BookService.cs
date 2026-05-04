using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Services
{
    public class BookService
    {
        private readonly IBookRepository bookRepo;
        private readonly IAuthorRepository authorRepo;

        public BookService(IBookRepository bookRepo, IAuthorRepository authorRepo)
        {
            this.bookRepo = bookRepo;
            this.authorRepo = authorRepo;
        }
        public void AddBook(string title, string genre, int authorId, int copies)
        {
            var author = authorRepo.GetById(authorId);

            if (author == null)
                throw new InvalidOperationException("Author not found.");

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
            book.Copies = copies;

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
