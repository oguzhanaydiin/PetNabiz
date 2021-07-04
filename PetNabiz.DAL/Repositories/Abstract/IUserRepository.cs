using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.DAL.Repositories.Abstract
{
    public interface IUserRepository : IRepository<User>
    {
        IEnumerable<User> GetTopUsers(int count);
        IEnumerable<User> GetAllUsers();
    }
}
