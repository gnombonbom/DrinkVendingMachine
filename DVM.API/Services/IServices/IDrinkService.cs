using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using System;
using System.Collections.Generic;

namespace DVM.API.Services.IServices
{
    public interface IDrinkService //переделать в базе на uniqueidentificator
    {
        void AddDrink(DrinkDb drink);
        List<Drink> GetAllDrinks();
        Drink GetDrinkById(Int32 id);
        void EditDrink(DrinkDb drink);
        void RemoveDrink(DrinkDb drink);
    }
}
