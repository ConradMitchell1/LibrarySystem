using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Services
{
    
    public class MagazineService: IMagazineService
    {
        private readonly IMagazineRepository _repository;

        public event MagazineActionHandler? OnMagazineBorrowed;
        public event MagazineActionHandler? OnMagazineReturned;
        public MagazineService(IMagazineRepository repository)
        {
            _repository = repository;
        }

        public bool Borrow(int id)
        {
            var mag = _repository.GetById(id);
            if (mag is null || mag.IsBorrowed) return false;
            mag.Borrow();

            OnMagazineBorrowed?.Invoke(mag);
            _repository.Update(mag);
            return true;
        }

        public IEnumerable<Magazine> GetAvailable()
        {
            return _repository.GetAll().Where(m => !m.IsBorrowed);
        }

        public bool Return(int id)
        {
            var mag = _repository.GetById(id);
            if (mag is null || !mag.IsBorrowed) return false;
            mag.Return();

            OnMagazineReturned?.Invoke(mag);
            _repository.Update(mag);
            return true;
        }

        public IEnumerable<Magazine> ReleasedAfter(DateTime date)
        {
            return _repository.GetAll().Where(m => m.ReleaseDate > date);
        }

        public IEnumerable<(string Category, int Count)> CountByCategory()
        {
            return _repository.GetAll()
                .GroupBy(m => m.Category)
                .Select(g => (Category: g.Key, Count: g.Count()));
        }

        public IEnumerable<Magazine> TopLatestIssues(int n)
        {
            return _repository.GetAll()
                .OrderByDescending(m => m.IssueNumber)
                .Take(n);
        }

        public IEnumerable<Magazine> SearchByTitle(string title)
        {
            return _repository.GetAll()
                .Where(m => m.Title.Contains(title, StringComparison.OrdinalIgnoreCase))
                .OrderBy(m => m.Title);
        }

        public IEnumerable<Magazine> SearchByCategory(string category)
        {
            return _repository.GetAll()
                .Where(m => m.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                .OrderBy(m => m.Title);
        }
    }
}
