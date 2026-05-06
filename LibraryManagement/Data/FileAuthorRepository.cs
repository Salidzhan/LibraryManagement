using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Data
{
    public class FileAuthorRepository : IAuthorRepository
    {
        private readonly FileStorage _fileStorage;

        public FileAuthorRepository(FileStorage fileStorage)
        {
            _fileStorage = fileStorage;
        }

        public List<Author> GetAll()
        {
            var db = _fileStorage.Load();
            return db.Authors;
        }

        public Author GetById(int id)
        {
            var db = _fileStorage.Load();

            var author = db.Authors.FirstOrDefault(a => a.Id == id);

            if (author == null)
                throw new InvalidOperationException("Author not found.");

            return author;
        }

        public void Save(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            if (string.IsNullOrWhiteSpace(author.Name))
                throw new ArgumentException("Author name is missing.");

            var db = _fileStorage.Load();

            if (author.Id == 0)
            {
                var newAuthor = new Author(db.NextId++, author.Name);
                db.Authors.Add(newAuthor);
            }
            else
            {
                var existing = db.Authors.FirstOrDefault(a => a.Id == author.Id);

                if (existing == null)
                    throw new InvalidOperationException("Author not found.");

                existing.Name = author.Name;
            }

            _fileStorage.Save(db);
        }
    }
}