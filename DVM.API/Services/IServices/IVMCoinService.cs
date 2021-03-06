using DVM.API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVM.API.Services.IServices
{
    public interface IVMCoinService
    {
        List<VMCoin> GetVMCoinsByVMId(Guid id);
        void RemoveVMCoin(Guid id);
    }
}
