using LibraryManagement.Models;
using System.Collections.Generic;

namespace LibraryManagement.Data
{
    public class LibraryStorage
    {
        public int NextId { get; set; } = 1;

        public List<Book> Books { get; set; } = new List<Book>();

        public List<Author> Authors { get; set; } = new List<Author>();

        public List<Member> Members { get; set; } = new List<Member>();
    }
}
