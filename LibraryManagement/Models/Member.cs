using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Models
{
    public class Member
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ActiveLoansCount { get; set; }


        public Member(int id, string firstName, string lastName, string email)
        {
            if (id < 0)
                throw new ArgumentException("Id must be positive");

            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email");

            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            ActiveLoansCount = 0;
        }

        public void AddLoan()
        {
            if (ActiveLoansCount >= 5)
                throw new Exception("Maximum 5 loans allowed");

            ActiveLoansCount++;
        }

        public void RemoveLoan()
        {
            if (ActiveLoansCount <= 0)
                throw new Exception("No active loans");

            ActiveLoansCount--;
        }

        public void Update(string firstName, string lastName, string email)
        {
            if (string.IsNullOrWhiteSpace(firstName))
                throw new ArgumentException("First name is required");

            if (string.IsNullOrWhiteSpace(lastName))
                throw new ArgumentException("Last name is required");

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@"))
                throw new ArgumentException("Invalid email");

            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}

