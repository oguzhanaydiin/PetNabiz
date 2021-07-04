using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.RequestModels
{
    [NotMapped]
    public class TokenRequestModel
    {
        public string Token { get; set; }
    }
}
