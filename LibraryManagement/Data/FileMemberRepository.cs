using LibraryManagement.Models;
using LibraryManagement.Services.Interfaces1;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement.Data
{
    public class FileMemberRepository : IMemberRepository
    {
        private readonly FileStorage storage;

        public FileMemberRepository(FileStorage storage)
        {
            this.storage = storage;
        }

        public List<Member> GetAll()
        {
            var db = storage.Load();
            return db.Members.ToList();
        }

        public void Save(Member member)
        {
            var db = storage.Load();

            if (member.Id == 0)
            {
                var newMember = new Member(
                    db.NextId++,
                    member.FirstName,
                    member.LastName,
                    member.Email
                );

                db.Members.Add(newMember);
            }
            else
            {
                var existing = db.Members.FirstOrDefault(m => m.Id == member.Id);

                if (existing == null)
                    throw new InvalidOperationException("Member not found.");

                existing.FirstName = member.FirstName;
                existing.LastName = member.LastName;
                existing.Email = member.Email;
                existing.ActiveLoansCount = member.ActiveLoansCount;
            }

            storage.Save(db);
        }
    }
}
