using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVM.API.Services.IServices
{
    public interface IVMDrinkService
    {
        void SaveVMDrink(VMDrinkDb vmDrink);
        List<VMDrink> GetVMDrinksByVMId(Guid id);
        void RemoveVMDrink(Guid id);
    }
}
