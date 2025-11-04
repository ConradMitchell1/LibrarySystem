using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Interfaces
{
    public delegate void BookActionHandler(Book book);
    public interface ILibraryService
    {
        IEnumerable<Book> GetAvailable();
        bool Borrow(int id);
        bool Return(int id);

        event BookActionHandler? OnBookBorrowed;
        event BookActionHandler? OnBookReturned;
    }
}
