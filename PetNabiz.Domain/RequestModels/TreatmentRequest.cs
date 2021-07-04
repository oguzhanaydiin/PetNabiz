using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.RequestModels
{
    [NotMapped]
    public class TreatmentRequestModel
    {
        public string PassportNumber { get; set; }
        public string VetName { get; set; }
        public string Info { get; set; }
    }
}
