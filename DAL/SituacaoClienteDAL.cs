using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO.Entities;

namespace DAL
{
    public class SituacaoClienteDAL
    {
        public List<SituacaoCliente> Get()
        {
            try
            {
                List<SituacaoCliente> lstSituacaoClientes = new List<SituacaoCliente>();

                var dataBase = DatabaseHelper.Create();
                dataBase.OpenConnection();

                using (dataBase.DbConnection)
                using (var cmd = new SqlCommand("sp_SituacaoCliente", dataBase.DbConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@command", "SELECT");

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        SituacaoCliente situacaoCliente = new SituacaoCliente
                        {
                            SituacaoClienteId = reader.GetInt32(0),
                            Nome = reader.GetString(1)
                        };

                        lstSituacaoClientes.Add(situacaoCliente);
                    }

                    return lstSituacaoClientes;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
