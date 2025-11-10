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
        public string Author { get;}
        public string Genre { get;}
        public int Year { get;}
        public bool IsBorrowed { get; private set; }

        public Book(int id, string title, string author, string genre, int year)
        {
            Id = id;
            Title = title;
            IsBorrowed = false;
            Author = author;
            Genre = genre;
            Year = year;
        }

        public void Borrow() => IsBorrowed = true;
        public void Return() => IsBorrowed = false;
    }
}
