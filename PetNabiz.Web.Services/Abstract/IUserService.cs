using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Web.Services.Abstract
{
    public interface IUserService
    {
        User Authenticate(string MailAddress, string Password);
    }
}
