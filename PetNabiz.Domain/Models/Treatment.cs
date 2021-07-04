using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.Models
{
    public class Treatment : BaseEntity
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public string VetName { get; set; }
        public string Info { get; set; }
    }
}
