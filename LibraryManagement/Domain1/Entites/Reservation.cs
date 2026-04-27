using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
   
    
        public class Reservation
        {
            public int Id { get; set; }
            public int BookId { get; set; }
            public int MemberId { get; set; }
            public DateTime ReservationDate { get; set; }

            public Reservation(int id, int bookId, int memberId)
            {
                if (id < 0)
                    throw new ArgumentException("Id must be positive");

                if (bookId <= 0)
                    throw new ArgumentException("BookId must be positive");

                if (memberId <= 0)
                    throw new ArgumentException("MemberId must be positive");

                Id = id;
                BookId = bookId;
                MemberId = memberId;
                ReservationDate = DateTime.Now;
            }
        }
}

