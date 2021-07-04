using PetNabiz.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetNabiz.Domain.ResponseModels
{
    public class SingleUserResponseModel
    {
        public SingleUserResponseModel(User items, string state, string errmessage)
        {
            Items = items;
            State = state;
            ErrorMessage = errmessage;
        }
        public User Items { get; set; }
        public string State { get; set; }
        public string ErrorMessage { get; set; }
    }
}
