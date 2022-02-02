using System;

namespace DVM.API.Models.Domain
{
    public class VMCoin
    {
        public Guid Id { get; }
        public Guid VMId { get; }
        public Coin Coin { get; }
        public Int32 Count { get; }
        public Boolean IsActive { get; }

        public VMCoin(Guid id, Guid vmid, Coin coin, Int32 count, Boolean isActive)
        {
            Id = id;
            VMId = vmid;
            Coin = coin;
            Count = count;
            IsActive = isActive;
        }
    }
}
