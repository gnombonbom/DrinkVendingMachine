using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using DVM.API.Services.IServices;
using DVM.API.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

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
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.Drink_GetAllDrinks, connect);

                List<DrinkDb> drinksDb = new();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        DrinkDb drinkDb = new()
                        {
                            Id = (Guid)reader["id"],
                            Name = (String)reader["name"],
                            Image = (Byte[])reader["image"],
                            Cost = (Int32)reader["cost"]
                        };
                        drinksDb.Add(drinkDb);
                    }
                }

                return Converter.ConvertToDrinks(drinksDb);
            }
        }

        public Drink GetDrinkById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ErrorException();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.Drink_GetDrinkById, connect);
                cmd.Parameters.AddWithValue("@p_id", id);

                DrinkDb drinkDb = new();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        drinkDb = new()
                        {
                            Id = (Guid)reader["id"],
                            Name = (String)reader["name"],
                            Image = (Byte[])reader["image"],
                            Cost = (Int32)reader["cost"]
                        };
                    }
                }

                return Converter.ConvertToDrink(drinkDb);
            }
        }

        public void RemoveDrink(Guid id)
        {
            if (id == Guid.Empty)
                throw new ErrorException();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.Drink_DeleteDrink, connect);
                cmd.Parameters.AddWithValue("@p_id", id);

                cmd.ExecuteNonQuery();
            }
        }
    }
}
