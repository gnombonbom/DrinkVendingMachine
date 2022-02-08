using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using DVM.API.Services.IServices;
using DVM.API.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DVM.API.Services
{
    public class VMCoinService : IVMCoinService
    {
        private String _connectionString = @"Data Source=DESKTOP-9SV6HT1\SQLEXPRESS;Initial Catalog=DrinkVendingMachine;Integrated Security=True";

        public List<VMCoin> GetVMCoinsByVMId(Guid id)
        {
            if (id == Guid.Empty)
                throw new ErrorException();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.VMCoin_GetVMCoinsByVMId, connect);
                cmd.Parameters.AddWithValue("@p_id", id);

                List<VMCoinDB> VMCoinDbs = new();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VMCoinDB VMCoinDb = new()
                        {
                            Id = (Guid)reader["id"],
                            VMId = (Guid)reader["vmid"],
                            CoinId = (Guid)reader["coinid"],
                            Count = (Int32)reader["count"],
                            IsActive = (Boolean)reader["isactive"]
                        };
                        VMCoinDbs.Add(VMCoinDb);
                    }
                }

                List<Coin> coins = new();
                for (Int32 count = 0; count < VMCoinDbs.Count; count++)
                {
                    coins.Add(GetCoinById(VMCoinDbs[count].CoinId));
                }

                return Converter.ConvertToVMCoins(VMCoinDbs, coins);
            }

        }

        private Coin GetCoinById(Guid id)
        {
            if (id == Guid.Empty)
                throw new ErrorException();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.Coin_GetCoinById, connect);
                cmd.Parameters.AddWithValue("@p_id", id);

                CoinDb coinDb = new();
                using (var reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        coinDb = new()
                        {
                            Id = (Guid)reader["id"],
                            Denomination = (Int32)reader["denomination"]
                        };
                    }
                }

                return new Coin(coinDb.Id, coinDb.Denomination);
            }
        }

        public void RemoveVMCoin(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
