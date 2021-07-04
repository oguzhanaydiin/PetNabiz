using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using PetNabiz.DAL;
using PetNabiz.Domain.Models;
using PetNabiz.Web.Services.Abstract;
using PetNabiz.Web.Services.Helpers;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace PetNabiz.Web.Services.Concrete
{
    public class UserService : IUserService
    {
        private UnitOfWork _UnitOfWork { get; set; }

        private IEnumerable<User> _users { get; set; }


        public UserService()
        {
            _UnitOfWork = new UnitOfWork(new DatabaseContext());
            _users = _UnitOfWork.UserRepository.GetAll();
        }

        public User Authenticate(string MailAddress, string Password)
        {
            var user = _users.SingleOrDefault(x => x.MailAddress == MailAddress && x.Password == Password);

            if (user == null)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            // Sifre null olarak gonderilir.
            user.Password = null;

            return user;
        }

        
    }
}
