using LibrarySystem.Interfaces;
using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Repositories
{
    public class InMemoryMagazineRepository : IMagazineRepository
    {
        private readonly List<Magazine> _magazines = new()
        {
            new Magazine(1, "Spooky Readings", "Horror", 1, DateTime.Now),
            new Magazine(2, "Wonderful Gardens", "Nature", 1, DateTime.Now),
            new Magazine(3, "Coding Weekly", "Computing", 1, DateTime.Now)
        };
        
        public IEnumerable<Magazine> GetAll()
        {
            return _magazines;
        }

        public Magazine GetById(int id)
        {
            return _magazines.First(m => m.Id == id);
        }

        public void Update(Magazine magazine)
        {
            var item = _magazines.FindIndex(m => m.Id == magazine.Id);
            if(item != -1) _magazines[item] = magazine;
        }
    }
}
