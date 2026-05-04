using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services
{
    public class AuthorService
    {
        private readonly IAuthorRepository authorRepo;

        public AuthorService(IAuthorRepository authorRepo)
        {
            this.authorRepo = authorRepo;
        }

        public void AddAuthor(string name)
        {
            var author = new Author(0, name);
            authorRepo.Save(author);
        }

        public IReadOnlyList<Author> GetAllAuthors()
        {
            return authorRepo.GetAll();
        }

        public Author GetAuthorById(int id)
        {
            return authorRepo.GetById(id);
        }
    }
}
