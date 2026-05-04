using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Data;
using LibraryManagement.Models;
using LibraryManagement.Services;
using LibraryManagement.Services.Interfaces1;

namespace LibraryManagement
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var storage = new FileStorage("library.json");

            IBookRepository bookRepo = new FileBookRepository(storage);
            //var memberRepo = new FileStorage<Member>(storage);
            //var loanRepo = new FileStorage<Loan>(storage);
            //var reservationRepo = new FileStorage<Reservation>(storage);

            var service = new BookService(bookRepo);

            //var ui = new LibraryUi(service);
            //object result = ui.Run();

            Console.WriteLine("1 Add Book");
            Console.WriteLine("2 Register Member");
            Console.WriteLine("3 Borrow Book");
            Console.WriteLine("4 Return Book");
            Console.WriteLine("5 Search Book");
            Console.WriteLine("6 Reports");

        }
    }
}
