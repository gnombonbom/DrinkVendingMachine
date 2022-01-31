using System;

namespace DVM.API.Models.Domain
{
    public class VendingMachine
    {
        public Int32 Id { get; }
        public String SecretCode { get; }

        public VendingMachine(Int32 id, String secretCode)
        {
            Id = id;
            SecretCode = secretCode;
        }
    }
}
