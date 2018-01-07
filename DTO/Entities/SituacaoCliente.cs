namespace DTO.Entities
{
    public class SituacaoCliente
    {
        public int SituacaoClienteId { get; set; }
        public string Nome { get; set; }

        public SituacaoCliente() { }

        public SituacaoCliente(string nome)
        {
            Nome = nome;
        }

        public SituacaoCliente(int situacaoClienteId, string nome)
        {
            SituacaoClienteId = situacaoClienteId;
            Nome = nome;
        }
    }
}
