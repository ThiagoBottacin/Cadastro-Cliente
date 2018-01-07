using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using DTO.Entities;

namespace DAL
{
    public class ClienteDAL
    {
        public void Insert(Cliente cliente)
        {
            try
            {
                var dataBase = DatabaseHelper.Create();
                dataBase.OpenConnection();

                using (dataBase.DbConnection)
                using (var cmd = new SqlCommand("sp_Cliente", dataBase.DbConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@command", "INSERT");
                    cmd.Parameters.AddWithValue("@clienteId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@tipoClienteId", cliente.TipoCliente.TipoClienteId);
                    cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@situacaoClienteId", cliente.SituacaoCliente.SituacaoClienteId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Update(Cliente cliente)
        {
            try
            {
                var dataBase = DatabaseHelper.Create();
                dataBase.OpenConnection();

                using (dataBase.DbConnection)
                using (var cmd = new SqlCommand("sp_Cliente", dataBase.DbConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@command", "UPDATE");
                    cmd.Parameters.AddWithValue("@clienteId", cliente.ClienteId);
                    cmd.Parameters.AddWithValue("@nome", cliente.Nome);
                    cmd.Parameters.AddWithValue("@cpf", cliente.Cpf);
                    cmd.Parameters.AddWithValue("@tipoClienteId", cliente.TipoCliente.TipoClienteId);
                    cmd.Parameters.AddWithValue("@sexo", cliente.Sexo);
                    cmd.Parameters.AddWithValue("@situacaoClienteId", cliente.SituacaoCliente.SituacaoClienteId);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Delete(int clienteId)
        {
            try
            {
                var dataBase = DatabaseHelper.Create();
                dataBase.OpenConnection();

                using (dataBase.DbConnection)
                using (var cmd = new SqlCommand("sp_Cliente", dataBase.DbConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@command", "DELETE");
                    cmd.Parameters.AddWithValue("@clienteId", clienteId);
                    cmd.Parameters.AddWithValue("@nome", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cpf", DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipoClienteId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@sexo", DBNull.Value);
                    cmd.Parameters.AddWithValue("@situacaoClienteId", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    
        public List<Cliente> Get()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();

                var dataBase = DatabaseHelper.Create();
                dataBase.OpenConnection();

                using (dataBase.DbConnection)
                using (var cmd = new SqlCommand("sp_Cliente", dataBase.DbConnection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@command", "SELECT");
                    cmd.Parameters.AddWithValue("@clienteId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@nome", DBNull.Value);
                    cmd.Parameters.AddWithValue("@cpf", DBNull.Value);
                    cmd.Parameters.AddWithValue("@tipoClienteId", DBNull.Value);
                    cmd.Parameters.AddWithValue("@sexo", DBNull.Value);
                    cmd.Parameters.AddWithValue("@situacaoClienteId", DBNull.Value);

                    var reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        Cliente cliente = new Cliente
                        {
                            ClienteId = reader.GetInt32(0),
                            Nome = reader.GetString(1),
                            Cpf = reader.GetString(2),
                            TipoCliente = new TipoCliente(reader.GetInt32(3), reader.GetString(4)),
                            Sexo = reader.GetString(5)[0],
                            SituacaoCliente = new SituacaoCliente(reader.GetInt32(6), reader.GetString(7))
                        };

                        clientes.Add(cliente);
                    }

                    return clientes;
                }
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
