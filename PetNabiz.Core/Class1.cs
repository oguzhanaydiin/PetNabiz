using System;
using System.Threading.Tasks;

namespace PetNabiz.Core
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> CommitAsync();
    }
}
