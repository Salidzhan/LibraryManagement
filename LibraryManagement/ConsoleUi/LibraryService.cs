using LibraryManagement.Models;

namespace LibraryManagement
{
    internal class LibraryService
    {
        private FileStorage<Book> bookRepo;
        private FileStorage<Member> memberRepo;
        private FileStorage<Loan> loanRepo;
        private FileStorage<Reservation> reservationRepo;

        public LibraryService(FileStorage<Book> bookRepo, FileStorage<Member> memberRepo, FileStorage<Loan> loanRepo, FileStorage<Reservation> reservationRepo)
        {
            this.bookRepo = bookRepo;
            this.memberRepo = memberRepo;
            this.loanRepo = loanRepo;
            this.reservationRepo = reservationRepo;
        }
    }
}