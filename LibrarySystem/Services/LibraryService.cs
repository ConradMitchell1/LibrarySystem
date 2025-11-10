using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IBookRepository _bookRepository;


        public event BookActionHandler? OnBookBorrowed;
        public event BookActionHandler? OnBookReturned;

        public LibraryService(IBookRepository bookRepository) 
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<Book> GetAvailable()
        {
            return _bookRepository.GetAll().Where(b => !b.IsBorrowed);
        }

        public bool Borrow(int id)
        {
            var book = _bookRepository.GetById(id);
            if (book == null || book.IsBorrowed) return false;
            book.Borrow();
            _bookRepository.Update(book);

            OnBookBorrowed?.Invoke(book);
            return true;
        }

        public bool Return(int id) 
        {
            var book = _bookRepository.GetById(id);
            if (book == null || !book.IsBorrowed) return false;
            book.Borrow();
            _bookRepository.Update(book);

            OnBookReturned?.Invoke(book);
            return true;
        }

        public IEnumerable<Book> SearchByTitle(string title)
        {
            return _bookRepository.GetAll().Where(b => b.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).OrderBy(b => b.Title);
        }

        public IEnumerable<Book> SearchByGenre(string genre)
        {
            return _bookRepository.GetAll().Where(b => b.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase)).OrderBy(b => b.Title);
        }

        public IEnumerable<Book> SearchByAuthor(string author)
        {
            return _bookRepository.GetAll().Where(b => b.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).OrderBy(b => b.Title);
        }

        public IEnumerable<IGrouping<string, Book>> GroupByGenre()
        {
            return _bookRepository.GetAll().GroupBy(b => b.Genre);
        }

        public IEnumerable<(string Genre, int Count)> CountByGenre()
        {
            return _bookRepository.GetAll()
                .GroupBy(b => b.Genre)
                .Select(g => (Genre: g.Key, Count: g.Count()))
                .OrderByDescending(g => g.Count);
        }

        public IEnumerable<Book> TopRecent(int n)
        {
            return _bookRepository.GetAll()
                .OrderByDescending(b => b.Year)
                .ThenBy(b => b.Title)
                .Take(n);
        }

        public (int Count, int MinYear, int MaxYear, double AvgYear) YearStats()
        {
            var years = _bookRepository.GetAll().Select(b => b.Year);
            return (years.Count(), years.Min(), years.Max(), years.Average());
        }
    }
}
