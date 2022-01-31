using System;

namespace DVM.API.Models.Domain
{
    class Coin
    {
        public Int32 Id { get; }
        public Int32 Denomination { get; }

        public Coin(Int32 id, Int32 denomination)
        {
            Id = id;
            Denomination = denomination;
        }
    }
}
