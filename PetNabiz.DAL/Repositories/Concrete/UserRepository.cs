using PetNabiz.DAL.Repositories.Abstract;
using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.DAL.Repositories.Concrete
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DatabaseContext context): base(context)
        {
            
        }
        public IEnumerable<User> GetAllUsers()
        {
            return DatabaseContext.Users.ToList();
        }

        public IEnumerable<User> GetTopUsers(int count)
        {
            return DatabaseContext.Users.Take(count);
        }

        

        public DatabaseContext DatabaseContext { get { return _context as DatabaseContext; } }
    }
}
