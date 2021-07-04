using PetNabiz.DAL.Repositories.Abstract;
using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.DAL.Repositories.Concrete
{
    public class TreatmentRepository : Repository<Treatment>, ITreatmentRepository
    {
        public TreatmentRepository(DatabaseContext context) : base(context)
        {

        }
        public IEnumerable<Treatment> GetAllTreatments()
        {
            return DatabaseContext.Treatments.ToList();
        }

        public IEnumerable<Treatment> GetTopTreatments(int count)
        {
            return DatabaseContext.Treatments.Take(count);
        }

        public DatabaseContext DatabaseContext { get { return _context as DatabaseContext; } }
    }
}
