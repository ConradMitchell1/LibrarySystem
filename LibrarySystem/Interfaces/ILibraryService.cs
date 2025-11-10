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
        IEnumerable<Book> SearchByTitle(string title);
        IEnumerable<Book> SearchByGenre(string genre);
        IEnumerable<Book> SearchByAuthor(string author);
        IEnumerable<IGrouping<string, Book>> GroupByGenre();
        IEnumerable<(string Genre, int Count)> CountByGenre();
        IEnumerable<Book> TopRecent(int n);
        (int Count, int MinYear, int MaxYear, double AvgYear) YearStats();
        bool Borrow(int id);
        bool Return(int id);

        event BookActionHandler? OnBookBorrowed;
        event BookActionHandler? OnBookReturned;
    }
}
