using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using DVM.API.Services.IServices;
using DVM.API.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVM.API.Services
{
    public class DrinkService : IDrinkService
    {
        public void AddDrink(DrinkDb drink)
        {
            if (drink.Name == "" || drink.Name == null)
                throw new ErrorException();

            if (drink.Cost == 0)
                throw new ErrorException();

            if (drink.Image.Length == 0)
                throw new ErrorException();

            if (drink.Id == Guid.Empty)
                drink.Id = Guid.NewGuid();

        }

        public List<Drink> GetAllDrinks()
        {
            throw new NotImplementedException();
        }

        public Drink GetDrinkById(int id)
        {
            throw new NotImplementedException();
        }
        public void EditDrink(DrinkDb drink)
        {
            throw new NotImplementedException();
        }

        public void RemoveDrink(DrinkDb drink)
        {
            throw new NotImplementedException();
        }
    }
}
