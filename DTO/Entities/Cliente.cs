using System.Runtime.CompilerServices;
using DTO.Exceptions;

namespace DTO.Entities
{
    public class Cliente
    {
        private string _cpf;

        public int ClienteId { get; set; }
        public string Nome { get; set; }

        public string Cpf
        {
            get
            {
                return this._cpf;
            }
            set
            {
                if (ValidaCpf(value))
                    this._cpf = value;
                else
                {
                    throw new ClienteException("CPF Inválido - Insira um CPF válido.");
                }
            } 
        }
        public TipoCliente TipoCliente { get; set; }
        public char Sexo { get; set; }
        public SituacaoCliente SituacaoCliente { get; set; }
        

        public Cliente() { }

        public Cliente(int clienteId, string nome, string cpf, string tipoCliente, char sexo, string situacaoCliente)
        {
            ClienteId = clienteId;
            Nome = nome;
            Cpf = cpf;
            TipoCliente = new TipoCliente(tipoCliente);
            Sexo = sexo;
            SituacaoCliente = new SituacaoCliente(situacaoCliente);
        }

        public Cliente(int clienteId, string nome, string cpf, int tipoClienteId, char sexo, int situacaoClienteId)
        {
            ClienteId = clienteId;
            Nome = nome;
            Cpf = cpf;
            TipoCliente = new TipoCliente {TipoClienteId = tipoClienteId};
            Sexo = sexo;
            SituacaoCliente = new SituacaoCliente{SituacaoClienteId = situacaoClienteId};
        }

        private static bool ValidaCpf(string cpf)
        {
            int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
            string tempCpf;
            string digito;
            int soma;
            int resto;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "").Replace("-", "");
            if (cpf.Length != 11)
                return false;
            tempCpf = cpf.Substring(0, 9);
            soma = 0;

            for (int i = 0; i < 9; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = resto.ToString();
            tempCpf = tempCpf + digito;
            soma = 0;
            for (int i = 0; i < 10; i++)
                soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];
            resto = soma % 11;
            if (resto < 2)
                resto = 0;
            else
                resto = 11 - resto;
            digito = digito + resto.ToString();
            return cpf.EndsWith(digito);
        }

        public static bool IsValid(Cliente cliente)
        {
            bool isValid = !(cliente == null || string.IsNullOrEmpty(cliente.Nome) || string.IsNullOrEmpty(cliente.Cpf) 
                || string.IsNullOrEmpty(cliente.Sexo.ToString()) || cliente.TipoCliente == null 
                || cliente.SituacaoCliente == null);

            return isValid;
        }
    }
}
