using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.RequestModels
{
    public class PetRequestModel
    {
        public string PassportNumber { get; set; }
        public string AnimalType { get; set; }
        public string Name { get; set; }
        public string NeutoringState { get; set; }
    }
}
