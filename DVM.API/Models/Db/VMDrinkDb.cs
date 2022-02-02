using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVM.API.Models.Db
{
    public class VMDrinkDb
    {
        public Guid Id { get; set; }
        public Guid VMId { get; set; }
        public Guid DrinkId { get; set; }
        public Int32 Count { get; set; }
    }
}
