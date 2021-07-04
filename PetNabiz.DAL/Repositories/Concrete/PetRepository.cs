using PetNabiz.DAL.Repositories.Abstract;
using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.DAL.Repositories.Concrete
{
    class PetRepository : Repository<Pet>, IPetRepository
    {
        public PetRepository(DatabaseContext context) : base(context)
        {

        }

        public IEnumerable<Pet> GetAllPets()
        {
            return DatabaseContext.Pets.ToList();
        }

        public IEnumerable<Pet> GetTopPets(int count)
        {
            return DatabaseContext.Pets.Take(count);
        }
        public DatabaseContext DatabaseContext { get { return _context as DatabaseContext; } }
    }
}
