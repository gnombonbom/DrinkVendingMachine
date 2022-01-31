using System;

namespace DVM.API.Models.Domain
{
    public class Drink
    {
        public Int32 Id { get; }
        public String Code { get; }
        public String Name { get; }
        public Byte[] Image { get; }
        public Int32 Cost { get; }

        public Drink(Int32 id, String code, String name, Byte[] image, Int32 cost)
        {
            Id = id;
            Code = code;
            Name = name;
            Image = image;
            Cost = cost;
        }
    }
}
