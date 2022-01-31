using System;

namespace DVM.API.Models.Domain
{
    class Coin
    {
        public Guid Id { get; }
        public Int32 Denomination { get; }

        public Coin(Guid id, Int32 denomination)
        {
            Id = id;
            Denomination = denomination;
        }
    }
}
