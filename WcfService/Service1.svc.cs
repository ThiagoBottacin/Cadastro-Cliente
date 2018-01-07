using System;
using System.Collections.Generic;
using DAL;
using DTO.Entities;
using DTO.Exceptions;

namespace WcfService
{
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

        public List<TipoCliente> GetTipoCliente()
        {

            return new TipoClienteDAL().Get();
        }

        public List<SituacaoCliente> GetSituacaoCliente()
        {
            
            return new SituacaoClienteDAL().Get();
        }

        public List<Cliente> GetClientes()
        {

            return new ClienteDAL().Get();
        }

        public string SaveCliente(Cliente cliente)
        {
            var msgResult = string.Empty;
            try
            {
                if (!Cliente.IsValid(cliente))
                    throw new ClienteException("Cliente inválido.");

                ClienteDAL clienteDal = new ClienteDAL();
                if (cliente.ClienteId == 0)
                    clienteDal.Insert(cliente);

                else if (cliente.ClienteId > 0)
                    clienteDal.Update(cliente);

                msgResult = "Registro salvo com sucesso";
            }
            catch (Exception e)
            {
                msgResult = $"Ocorreu um erro ao salvar o registro.\\nDetalhes: {e.Message}";
            }
            
            return msgResult;
        }

        public string DeleteCliente(int clienteId)
        {
            var msgResult = string.Empty;
            try
            {
                if (clienteId == 0)
                    throw new ClienteException("Registro inválido.");

                new ClienteDAL().Delete(clienteId);

                msgResult = "Registro deletado com sucesso";
            }
            catch (Exception e)
            {
                msgResult = $"Ocorreu um erro ao deletar o registro.\\nDetalhes: {e.Message}";
            }

            return msgResult;
        }
    }
}
