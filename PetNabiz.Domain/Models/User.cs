using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.Models
{
    public class User : BaseEntity

    {
        public int Id { get; set; }
        public string UserType { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string BirthDate { get; set; }
        public string Name { get; set; }
        public string VetName { get; set; }

        [NotMapped]
        public string Token{ get; set; }
    }
}
