using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.Models
{
    public class Pet:BaseEntity
    {
        public int Id { get; set; }
        public string PassportNumber { get; set; }
        public string AnimalType { get; set; }
        public string Name { get; set; }
        public string NeutoringState { get; set; }
    }
}
