using DVM.API.Models.Domain;
using DVM.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVM.API.Controllers
{
    public class VMDrinkController
    {
        private VMDrinkService _service = new();

        public List<VMDrink> GetVMDrinks(Guid id)
        {
            return _service.GetVMDrinksByVMId(id);
        }

    }
}
