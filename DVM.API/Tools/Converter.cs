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

        public static List<VMDrink> ConvertToVMDrinks(List<VMDrinkDb> VMDrinksDb, List<Drink> drinks)
        {
            List<VMDrink> VMDrinks = new();
            for (Int32 count = 0; count < VMDrinksDb.Count; count++)
            {
                VMDrinks.Add(ConvertToVMDrink(VMDrinksDb[count], drinks[count]));
            }

            return VMDrinks;
        }

        public static VMDrink ConvertToVMDrink(VMDrinkDb VMDrinkDb, Drink drink)
        {
            return new VMDrink(VMDrinkDb.Id, VMDrinkDb.VMId, drink, VMDrinkDb.Count);
        }

        public static List<VMCoin> ConvertToVMCoins(List<VMCoinDB> VMCoinDbs, List<Coin> coins)
        {
            List<VMCoin> VMCoins = new();
            for (Int32 count = 0; count < VMCoinDbs.Count; count++)
                VMCoins.Add(ConvertToVMCoin(VMCoinDbs[count], coins[count]));

            return VMCoins;

        }

        public static VMCoin ConvertToVMCoin(VMCoinDB coinDb, Coin coin)
        {
            return new VMCoin(coinDb.Id, coinDb.VMId, coin, coinDb.Count, coinDb.IsActive);
        }
        
    }
}
