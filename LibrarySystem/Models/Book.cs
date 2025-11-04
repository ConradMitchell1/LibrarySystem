using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Models
{
    public class Book
    {
        public int Id { get; }
        public string Title { get;}
        public bool IsBorrowed { get; private set; }

        public Book(int id, string title)
        {
            Id = id;
            Title = title;
            IsBorrowed = false;
        }

        public void Borrow() => IsBorrowed = true;
        public void Return() => IsBorrowed = false;
    }
}
