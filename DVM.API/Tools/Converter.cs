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

        private static Drink ConvertToDrink(DrinkDb drink)
        {
            return new Drink(drink.Id, drink.Name, drink.Image, drink.Cost);
        }
    }
}
