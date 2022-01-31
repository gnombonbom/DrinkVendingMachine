using System;

namespace DVM.API.Models.Db
{
    public class VendingMachineDb
    {
        public Guid Id { get; set; }
        public String SecretCode { get; set; }
    }
}
