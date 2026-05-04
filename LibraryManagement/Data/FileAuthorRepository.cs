using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
           var db =  _fileStorage.Load();
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
                throw new ArgumentException("Author name is missing.", nameof(author));

            var db = _fileStorage.Load();

            if (author.Id == 0)
            {
                var newAuthor = new Author(
                    db.NextId++,
                    author.Name
                    );

                db.Authors.Add(newAuthor);
            }
            else
            {

                var index = db.Books.FindIndex(b => b.Id == author.Id);

                if (index == -1)
                    throw new InvalidOperationException("Book not found.");

                db.Authors[index] = author;


            }
            _fileStorage.Save(db);
        }
    }
}
