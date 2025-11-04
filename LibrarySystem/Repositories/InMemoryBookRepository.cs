using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Repositories
{
    internal class InMemoryBookRepository : IBookRepository
    {
        private readonly List<Book> _books = new()
        {
            new Book ( 1, "Blue Book" ),
            new Book (2, "Red Book"),
            new Book (3, "Green Book")
        };
        public IEnumerable<Book> GetAll()
        {
            return _books;
        }

        public Book GetById(int id)
        {
            return _books.First(x => x.Id == id);
        }

        public void Update(Book book)
        {
            var index = _books.FindIndex(b => b.Id == book.Id);
            if (index != -1)
            {
                _books[index] = book;
            }
        }
    }
}
