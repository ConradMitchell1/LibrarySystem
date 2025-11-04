using LibrarySystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.Interfaces
{
    public interface IMagazineRepository
    {
        IEnumerable<Magazine> GetAll();
        Magazine GetById(int id);
        void Update(Magazine magazine);
    }
}
