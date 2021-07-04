using PetNabiz.DAL.Repositories.Abstract;
using PetNabiz.DAL.Repositories.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private DatabaseContext _databaseContext;

        public UnitOfWork(DatabaseContext context)
        {
            _databaseContext = context;
            UserRepository = new UserRepository(_databaseContext);
            PetRepository = new PetRepository(_databaseContext);
            TreatmentRepository = new TreatmentRepository(_databaseContext);
        }
        public IUserRepository UserRepository { get; private set; }

        public IPetRepository PetRepository { get; private set; }
        public ITreatmentRepository TreatmentRepository { get; private set; }

        public int Complete()
        {
            return _databaseContext.SaveChanges();
        }

        public void Dispose()
        {
            _databaseContext.Dispose();
        }
    }
}
