using LibraryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Services.Interfaces1
{
    public interface IBookRepository
    {
        Book GetById(int id);

        IReadOnlyList<Book> GetAll();
        void Save(Book book);
        void Delete(int id);
    }

}
