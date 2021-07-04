using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.DAL.Repositories.Abstract
{
    public interface ITreatmentRepository : IRepository<Treatment>
    {
        IEnumerable<Treatment> GetTopTreatments(int count);
        IEnumerable<Treatment> GetAllTreatments();
    }
}

