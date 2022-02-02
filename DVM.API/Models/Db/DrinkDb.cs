using System;

namespace DVM.API.Models.Db
{
    public class DrinkDb
    {
        public Guid Id { get; set; }
        public String Name { get; set; }
        public Byte[] Image { get; set; }
        public Int32 Cost { get; set; }
    }
}
