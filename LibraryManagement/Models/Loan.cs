using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Loan
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int MemberId { get; set; }
        public DateTime LoanDate { get; set; }
        public DateTime DueDate { get; set; }
        public DateTime? ReturnDate { get; set; }


        public Loan(int id, int bookId, int memberId, DateTime loanDate, DateTime dueDate)
        {
            if (id < 0)
                throw new ArgumentException("Id must be positive");

            if (bookId <= 0)
                throw new ArgumentException("BookId must be positive");

            if (memberId <= 0)
                throw new ArgumentException("MemberId must be positive");

            if (dueDate <= loanDate)
                throw new ArgumentException("Due date must be after loan date");

            Id = id;
            BookId = bookId;
            MemberId = memberId;
            LoanDate = loanDate;
            DueDate = dueDate;
        }

        public void Return()
        {
            if (ReturnDate != null)
                throw new Exception("Book already returned");

            ReturnDate = DateTime.Now;
        }
    }
}
