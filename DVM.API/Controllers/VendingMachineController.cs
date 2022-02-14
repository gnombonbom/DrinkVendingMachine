using DVM.API.Models.Domain;
using DVM.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVM.API.Controllers
{
    public class VendingMachineController
    {
        private VendingMachineService _service = new();

        public VendingMachine GetVendingMachineBySecretCode(String code)
        {
            return _service.GetVendingMachineBySecretCode(code);
        }
    }
}
