using PetNabiz.DAL.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.DAL
{
    public interface IUnitOfWork: IDisposable
    {
        IUserRepository UserRepository { get;  }
        IPetRepository PetRepository { get; }
        ITreatmentRepository TreatmentRepository { get; }

        int Complete();
    }
}
