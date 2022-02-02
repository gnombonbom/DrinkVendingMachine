using System;

namespace DVM.API.Models.Domain
{
    public class VMDrink
    {
        public Guid Id { get; }
        public Guid VMId { get; }
        public Drink Drink { get; }
        public Int32 Count { get; }

        public VMDrink(Guid id, Guid vmId, Drink drink, Int32 count)
        {
            Id = id;
            VMId = vmId;
            Drink = drink;
            Count = count;
        }
    }
}
