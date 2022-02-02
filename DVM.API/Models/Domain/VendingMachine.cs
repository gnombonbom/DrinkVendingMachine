using System;

namespace DVM.API.Models.Domain
{
    public class VendingMachine
    {
        public Guid? Id { get; }
        public String SecretCode { get; }

        public VendingMachine(Guid id, String secretCode)
        {
            Id = id;
            SecretCode = secretCode;
        }
    }
}
