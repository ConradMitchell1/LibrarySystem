using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Magazine
    {
        public int Id { get; }
        public string Title { get; }
        public string Category { get; }
        public int IssueNumber { get; }
        public DateTime ReleaseDate { get; set; }
        public bool IsBorrowed { get; private set; }

        public Magazine(int id, string title, string category, int issueNumber, DateTime releaseDate)
        {
            Id = id;
            Title = title;
            IsBorrowed = false;
            Category = category;
            IssueNumber = issueNumber;
            ReleaseDate = releaseDate;
        }

        public void Borrow() => IsBorrowed = true;
        public void Return() => IsBorrowed = false;
    }
}
