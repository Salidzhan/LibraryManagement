using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Services
{
    public class LoanService
    {
        private readonly ILoanRepository loanRepo;
        private readonly IBookRepository bookRepo;
        private readonly IMemberRepository memberRepo;

        public LoanService(
            ILoanRepository loanRepo,
            IBookRepository bookRepo,
            IMemberRepository memberRepo)
        {
            this.loanRepo = loanRepo;
            this.bookRepo = bookRepo;
            this.memberRepo = memberRepo;
        }

        public void CreateLoan(int bookId, int memberId)
        {
            var book = bookRepo.GetById(bookId);
            var member = memberRepo.GetAll().FirstOrDefault(m => m.Id == memberId);

            if (book == null)
                throw new Exception("Book not found");

            if (member == null)
                throw new Exception("Member not found");

            if (book.Copies <= 0)
                throw new Exception("No available copies");

            member.AddLoan();
            book.Borrow();

            var loan = new Loan(
                id: 0,
                bookId: bookId,
                memberId: memberId,
                loanDate: DateTime.Now,
                dueDate: DateTime.Now.AddDays(14)
            );

            loanRepo.Save(loan);
        }

        public void ReturnLoan(int loanId)
        {
            var loan = loanRepo.GetAll().FirstOrDefault(l => l.Id == loanId);

            if (loan == null)
                throw new Exception("Loan not found");

            if (loan.ReturnDate != null)
                throw new Exception("Already returned");

            var book = bookRepo.GetById(loan.BookId);
            var member = memberRepo.GetAll().FirstOrDefault(m => m.Id == loan.MemberId);

            loan.Return();
            book.Return();
            member.RemoveLoan();
        }

        public List<Loan> GetOverdueLoans()
        {
            return loanRepo.GetAll()
                .Where(l => l.ReturnDate == null && l.DueDate < DateTime.Now)
                .ToList();
        }

        public decimal CalculateFine(int loanId)
        {
            var loan = loanRepo.GetAll().FirstOrDefault(l => l.Id == loanId);

            if (loan == null)
                throw new Exception("Loan not found");

            if (loan.ReturnDate == null || loan.DueDate >= DateTime.Now)
                return 0;

            var daysLate = (DateTime.Now - loan.DueDate).Days;

            return daysLate * 1.5m; 
        }
    }
}
