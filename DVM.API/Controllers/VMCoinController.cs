using DVM.API.Models.Domain;
using DVM.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVM.API.Controllers
{
    public class VMCoinController
    {
        private VMCoinService _service = new();
        
        public List<VMCoin> GetVMCoins(Guid id)
        {
            return _service.GetVMCoinsByVMId(id);
        } 
    }
}
