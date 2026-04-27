using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Author(int id, string name)
        {
            if (id < 0)
                throw new ArgumentException("Id must be positive");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Author name is required");

            Id = id;
            Name = name;
        }
    }
}
