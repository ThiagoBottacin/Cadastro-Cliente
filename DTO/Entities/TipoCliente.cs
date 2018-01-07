namespace DTO.Entities
{
    public class TipoCliente
    {
        public int TipoClienteId { get; set; }
        public string Nome { get; set; }

        public TipoCliente() { }

        public TipoCliente(string nome)
        {
            Nome = nome;
        }

        public TipoCliente(int tipoClienteId, string nome)
        {
            TipoClienteId = tipoClienteId;
            Nome = nome;
        }
    }
}
