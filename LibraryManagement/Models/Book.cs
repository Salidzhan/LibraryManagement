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
        public int AvailableCopies { get; set; }
        public int LoanCount { get; set; }



        public Book(int id, string title, string genre, int authorId, int copies)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("Title required");

            Id = id;
            Title = title;
            Genre = genre;
            AuthorId = authorId;
            AvailableCopies = copies;
            LoanCount = 0;
        }

        public void Borrow()
        {
            if (AvailableCopies <= 0)
                throw new Exception("No copies available");

            AvailableCopies--;
            LoanCount++;
        }

        public void Return()
        {
            AvailableCopies++;
        }
    }
}


