using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVM.API.Services.IServices
{
    public interface IVendingMachineService
    {
        void SaveMachine(VendingMachineDb VMDb);
        List<VendingMachine> GetAllMachines();
        void RemoveMachine(Guid id);
    }
}
