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
            List<Book> GetAll();
            void Save(Book book);
        }
    
}
