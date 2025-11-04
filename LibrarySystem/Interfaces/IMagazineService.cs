using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Interfaces
{
    public delegate void MagazineActionHandler(Magazine magazine);
    public interface IMagazineService
    {
        IEnumerable<Magazine> GetAvailable();
        bool Borrow(int id);
        bool Return(int id);

        event MagazineActionHandler? OnMagazineBorrowed;
        event MagazineActionHandler? OnMagazineReturned;
    }
}
