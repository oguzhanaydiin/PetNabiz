using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.ResponseModels
{
    public class TreatmentResponseModel
    {
        public TreatmentResponseModel(IEnumerable<Treatment> items, string state, string errmessage)
        {
            Items = items;
            State = state;
            ErrorMessage = errmessage;
        }
        public IEnumerable<Treatment> Items { get; set; }
        public string State { get; set; }
        public string ErrorMessage { get; set; }
    }
}
