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
    }
}
