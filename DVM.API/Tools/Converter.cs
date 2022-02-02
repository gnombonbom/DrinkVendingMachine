using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVM.API.Tools
{
    public static class Converter
    {
        public static List<Drink> ConvertToDrinks(List<DrinkDb> drinkdb)
        {
            List<Drink> drinks = new();
            foreach (DrinkDb drink in drinkdb)
                drinks.Add(ConvertToDrink(drink));

            return drinks;
        }

        public static Drink ConvertToDrink(DrinkDb drink)
        {
            return new Drink(drink.Id, drink.Name, drink.Image, drink.Cost);
        }

        public static List<VendingMachine> ConvertToVMs(List<VendingMachineDb> VMDbs)
        {
            List<VendingMachine> VMs = new();
            foreach (VendingMachineDb VMDb in VMDbs)
                VMs.Add(ConvertToVM(VMDb));

            return VMs;
        }

        public static VendingMachine ConvertToVM(VendingMachineDb VMDb)
        {
            return new VendingMachine(VMDb.Id, VMDb.SecretCode);
        }

        
    }
}
