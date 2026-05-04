using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{ 
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int AuthorId { get; set; }
        public int Copies { get; set; }
        public int LoanCount { get; set; }



        public Book(int id, string title, string genre, int authorId, int copies)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title required");

            Id = id;
            Title = title;
            Genre = genre;
            AuthorId = authorId;
            Copies = copies;
            LoanCount = 0;
        }

        public void Borrow()
        {
            if (Copies <= 0)
                throw new Exception("No copies available");

            Copies--;
            LoanCount++;
        }

        public void Return()
        {
            Copies++;
        }
    }
}


