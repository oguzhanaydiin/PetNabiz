using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.RequestModels
{
    [NotMapped]
    public class UserRequestModel
    {
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Name { get; set; }
        public string VetName { get; set; }
    }
}
