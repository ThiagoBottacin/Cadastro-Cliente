using System;
using System.Collections.Generic;
using System.Data;
using DTO.Entities;
using System.Data.SqlClient;

namespace DAL
{
    public class TipoClienteDAL
    {
        public List<TipoCliente> Get()
        {
            try
            {
                List<TipoCliente> lstTipoClientes = new List<TipoCliente>();

                var dataBase = DatabaseHelper.Create();
                dataBase.OpenConnection();

                using (dataBase.DbConnection)
                using (var cmd = new SqlCommand("sp_TipoCliente", dataBase.DbConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@command", "SELECT");

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        TipoCliente tipoCliente = new TipoCliente
                        {
                            TipoClienteId = reader.GetInt32(0),
                            Nome = reader.GetString(1)
                        };

                        lstTipoClientes.Add(tipoCliente);
                    }

                    return lstTipoClientes;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
