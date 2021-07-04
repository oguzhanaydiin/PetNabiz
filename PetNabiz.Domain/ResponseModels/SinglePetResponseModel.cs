using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.ResponseModels
{
    public class SinglePetResponseModel
    {
        public SinglePetResponseModel(Pet items, string state, string errmessage)
        {
            Items = items;
            State = state;
            ErrorMessage = errmessage;
        }
        public Pet Items { get; set; }
        public string State { get; set; }
        public string ErrorMessage { get; set; }
    }
}
