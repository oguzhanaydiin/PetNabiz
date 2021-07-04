using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Core.Models
{
    public class User
    {
        public int Id { get; set; }
        public string UserType { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Name { get; set; }
        public string VetName { get; set; }

    }
}
