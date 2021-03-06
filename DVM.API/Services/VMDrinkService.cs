using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using DVM.API.Services.IServices;
using DVM.API.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DVM.API.Services
{
    public class VMDrinkService : IVMDrinkService
    {
        private String _connectionString = @"Data Source=Mikhuil;Initial Catalog=DrinkVendingMachine;Integrated Security=True";

        public void SaveVMDrink(VMDrinkDb vmDrink)
        {
            if (vmDrink.Count < 0)
                throw new ErrorException();

            if (vmDrink.DrinkId == Guid.Empty)
                throw new ErrorException();

            if (vmDrink.VMId == Guid.Empty)
                throw new ErrorException();

            if (vmDrink.Id == Guid.Empty)
                vmDrink.Id = Guid.NewGuid();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.VMDrink_SaveVMDrink, connect);
                cmd.Parameters.AddWithValue("@p_id", vmDrink.Id);
                cmd.Parameters.AddWithValue("@p_vmid", vmDrink.VMId);
                cmd.Parameters.AddWithValue("@p_drinkid", vmDrink.DrinkId);
                cmd.Parameters.AddWithValue("@p_count", vmDrink.Count);
                cmd.ExecuteNonQuery();
            }
        }

        public List<VMDrink> GetVMDrinksByVMId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ErrorException();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.VMDrink_GetVMDrinksByVMId, connect);
                cmd.Parameters.AddWithValue("@p_id", id);

                List<VMDrinkDb> VMDrinksDb = new();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VMDrinkDb VMDrinkDb = new()
                        {
                            Id = (Guid)reader["id"],
                            VMId = (Guid)reader["vmid"],
                            DrinkId = (Guid)reader["drinkid"],
                            Count = (Int32)reader["count"]
                        };
                        VMDrinksDb.Add(VMDrinkDb);
                    }
                }

                List<Drink> drinks = new();
                DrinkService drinkService = new();
                for (Int32 count = 0; count < VMDrinksDb.Count; count++)
                {
                    Drink drinkDb = drinkService.GetDrinkById(VMDrinksDb[count].DrinkId);
                    drinks.Add(drinkDb);
                }

                return Converter.ConvertToVMDrinks(VMDrinksDb, drinks);
            }
        }

        public void RemoveVMDrink(Guid id)
        {
            if (id == Guid.Empty)
                throw new ErrorException();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.VMDrink_RemoveVMDrink_sql, connect);
                cmd.Parameters.AddWithValue("@p_id", id);

                cmd.ExecuteNonQuery();
            }
        }

    }
}
