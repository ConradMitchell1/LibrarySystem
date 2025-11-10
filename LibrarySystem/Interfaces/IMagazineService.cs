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
        IEnumerable<Magazine> ReleasedAfter(DateTime date);
        IEnumerable<(string Category, int Count)> CountByCategory();
        IEnumerable<Magazine> TopLatestIssues(int n);
        IEnumerable<Magazine> GetAvailable();
        IEnumerable<Magazine> SearchByTitle(string title);
        IEnumerable<Magazine> SearchByCategory(string category);

        bool Borrow(int id);
        bool Return(int id);

        event MagazineActionHandler? OnMagazineBorrowed;
        event MagazineActionHandler? OnMagazineReturned;
    }
}
