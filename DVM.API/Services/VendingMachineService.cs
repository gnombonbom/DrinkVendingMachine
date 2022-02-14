using DVM.API.Models.Db;
using DVM.API.Models.Domain;
using DVM.API.Services.IServices;
using DVM.API.Tools;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DVM.API.Services
{
    public class VendingMachineService : IVendingMachineService
    {
        private String _connectionString = @"Data Source=Mikhuil;Initial Catalog=DrinkVendingMachine;Integrated Security=True";

        public void SaveMachine(VendingMachineDb VMDb)
        {
            if (VMDb.SecretCode == "")
                throw new ErrorException();

            if (VMDb.Id == Guid.Empty)
                VMDb.Id = Guid.NewGuid();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.VendingMachine_SaveMachine, connect);
                cmd.Parameters.AddWithValue("@p_id", VMDb.Id);
                cmd.Parameters.AddWithValue("@p_secretcode", VMDb.SecretCode);
                cmd.ExecuteNonQuery();
            }
        }

        public List<VendingMachine> GetAllMachines()
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.VendingMachine_GetAllMachines, connect);

                List<VendingMachineDb> VMDbs = new();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VendingMachineDb VMDb = new()
                        {
                            Id = (Guid)reader["id"],
                            SecretCode = (String)reader["secretcode"]
                        };
                        VMDbs.Add(VMDb);
                    }
                }
                return Converter.ConvertToVMs(VMDbs);
            }
        }

        public VendingMachine GetVendingMachineBySecretCode(String code)
        {
            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.VendingMachine_GetVendingMachineBySecretCode, connect);
                cmd.Parameters.AddWithValue("@p_secretcode", code);

                VendingMachineDb VMDb = new();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        VMDb = new()
                        {
                            Id = (Guid)reader["id"],
                            SecretCode = (String)reader["secretcode"]
                        };
                    }
                }
                return Converter.ConvertToVM(VMDb);
            }
            
        }

        public void RemoveMachine(Guid id)
        {
            if (id == Guid.Empty)
                throw new ErrorException();

            using (SqlConnection connect = new(_connectionString))
            {
                connect.Open();
                SqlCommand cmd = new(SQL.Sql.VendingMachine_DeleteMachine, connect);
                cmd.Parameters.AddWithValue("@p_id", id);
                cmd.ExecuteNonQuery();
            }
        }

    }
}
