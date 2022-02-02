using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using System;
using System.Collections.Generic;

namespace DVM.API.Services.IServices
{
    public interface IDrinkService
    {
        void SaveDrink(DrinkDb drink);
        List<Drink> GetAllDrinks();
        Drink GetDrinkById(Guid id);
        void RemoveDrink(Guid id);
    }
}
