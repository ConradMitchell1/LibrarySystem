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
    }
}
