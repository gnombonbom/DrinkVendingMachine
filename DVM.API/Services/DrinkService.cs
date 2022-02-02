using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using DVM.API.Services.IServices;
using DVM.API.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DVM.API.Services
{
    public class DrinkService : IDrinkService
    {
        private String _connectionString = @"Data Source=DESKTOP-9SV6HT1\SQLEXPRESS;Initial Catalog=DrinkVendingMachine;Integrated Security=True";

        public void SaveDrink(DrinkDb drink)
        {
            if (drink.Name == "")
                throw new ErrorException();

            if (drink.Cost == 0)
                throw new ErrorException();

            if (drink.Image.Length == 0)
                throw new ErrorException();

            if (drink.Id == Guid.Empty)
                drink.Id = Guid.NewGuid();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.Drink_SaveDrink, connect);
                cmd.Parameters.AddWithValue("@p_id", drink.Id);
                cmd.Parameters.AddWithValue("@p_name", drink.Name);
                cmd.Parameters.AddWithValue("@p_image", drink.Image);
                cmd.Parameters.AddWithValue("@p_cost", drink.Cost);
                cmd.ExecuteNonQuery();
            }
        }

        public List<Drink> GetAllDrinks()
        {
            throw new NotImplementedException();
        }

        public Drink GetDrinkById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void RemoveDrink(DrinkDb drink)
        {
            throw new NotImplementedException();
        }
    }
}
