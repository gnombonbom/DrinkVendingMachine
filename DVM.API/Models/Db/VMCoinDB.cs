using System;

namespace DVM.API.Models.Db
{
    public class VMCoinDB
    {
        public Guid Id { get; set; }
        public Guid VMId { get; set; }
        public Guid CoinId { get; set; }
        public Int32 Count { get; set; }
        public Boolean IsActive { get; set; }
    }
}
