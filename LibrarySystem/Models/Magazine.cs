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
        public string Genre { get; }
        public bool IsBorrowed { get; private set; }

        public Magazine(int id, string title, string genre)
        {
            Id = id;
            Title = title;
            IsBorrowed = false;
            Genre = genre;
        }

        public void Borrow() => IsBorrowed = true;
        public void Return() => IsBorrowed = false;
    }
}
