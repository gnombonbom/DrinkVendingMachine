using System;

namespace DVM.API.Models.Domain
{
    public class Drink
    {
        public Guid? Id { get; }
        public String Name { get; }
        public Byte[] Image { get; }
        public Int32 Cost { get; }

        public Drink(Guid id, String name, Byte[] image, Int32 cost)
        {
            Id = id;
            Name = name;
            Image = image;
            Cost = cost;
        }
    }
}
