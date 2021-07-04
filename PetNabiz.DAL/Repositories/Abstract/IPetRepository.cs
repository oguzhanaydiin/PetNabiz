using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.DAL.Repositories.Abstract
{
    public interface IPetRepository : IRepository<Pet>
    {
        IEnumerable<Pet> GetTopPets(int count);
        IEnumerable<Pet> GetAllPets();
    }
}
