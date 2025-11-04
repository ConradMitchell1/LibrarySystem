using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using LibrarySystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.UI
{
    public class ConsoleUI
    {
        private readonly ILibraryService _libraryService;
        private readonly IMagazineService _magazineService;
        public ConsoleUI(ILibraryService libraryService, IMagazineService magazineService) 
        {
            _libraryService = libraryService;
            _magazineService = magazineService;

            _libraryService.OnBookBorrowed += HandleBookBorrowed;
            _libraryService.OnBookReturned += HandleBookReturned;
            _magazineService.OnMagazineBorrowed += HandleMagazineBorrowed;
            _magazineService.OnMagazineReturned += HandleMagazineReturned;
        }
        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n1. View Books\n2. Borrow Book\n3. Return Book\n4. View Magazines\n5. Borrow Magazine\n6. Return Magazine\n7. Exit");
                Console.WriteLine("Choice: ");

                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ViewBooks();
                        break;
                    case "2":
                        BorrowBook();
                        break;
                    case "3":
                        ReturnBook();
                        break;
                    case "4":
                        ViewMagazines();
                        break;
                    case "5":
                        BorrowMagazine();
                        break;
                    case "6":
                        ReturnMagazine();
                        break;
                    case "7":
                        return;

                }
            }
        }

        private void ViewBooks()
        {
            foreach (var book in _libraryService.GetAvailable())
            {
                Console.WriteLine($"{book.Id}: {book.Title} - {(book.IsBorrowed ? "Borrowed" : "Available")}");
            }
        }

        private void BorrowBook()
        {
            Console.WriteLine("Enter book ID: ");
            if (int.TryParse(Console.ReadLine(), out int borrowId) && _libraryService.Borrow(borrowId)) Console.WriteLine("Book borrowed!");
            else Console.WriteLine("Unable to borrow book.");
        }

        private void ReturnBook()
        {
            Console.WriteLine("Enter book ID: ");
            if (int.TryParse(Console.ReadLine(), out int returnId) && _libraryService.Return(returnId)) Console.WriteLine("Book returned!");
            else Console.WriteLine("Unable to return book.");
        }
        private void ViewMagazines()
        {
            foreach (var book in _magazineService.GetAvailable())
            {
                Console.WriteLine($"{book.Id}: {book.Title} - {(book.IsBorrowed ? "Borrowed" : "Available")}");
            }
        }

        private void BorrowMagazine()
        {
            Console.WriteLine("Enter Magazine ID: ");
            if (int.TryParse(Console.ReadLine(), out int borrowId) && _magazineService.Borrow(borrowId)) Console.WriteLine("Magazine borrowed!");
            else Console.WriteLine("Unable to borrow Magazine.");
        }

        private void ReturnMagazine()
        {
            Console.WriteLine("Enter Magazine ID: ");
            if (int.TryParse(Console.ReadLine(), out int returnId) && _magazineService.Return(returnId)) Console.WriteLine("Magazine returned!");
            else Console.WriteLine("Unable to return Magazine.");
        }

        private void HandleBookBorrowed(Book book)
        {
            Console.WriteLine($"[EVENT] '{book.Title}' has been borrowed.");
        }
        private void HandleBookReturned(Book book)
        {
            Console.WriteLine($"[EVENT] '{book.Title}' has been returned.");
        }
        private void HandleMagazineBorrowed(Magazine magazine)
        {
            Console.WriteLine($"[EVENT] '{magazine.Title}' has been borrowed.");
        }
        private void HandleMagazineReturned(Magazine magazine)
        {
            Console.WriteLine($"[EVENT] '{magazine.Title}' has been returned.");
        }
    }
}
