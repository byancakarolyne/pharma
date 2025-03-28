namespace PharmaApp.Components.Pages
{
    public class ComposicaoDto
    {
        public int MateriaPrimaId { get; set; }
        public int QuantidadeUtilizada { get; set; }
    }

    public class MedicamentoDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int QuantidadeEmEstoque { get; set; }
        public decimal Preco { get; set; }

        // Adicionando a lista de composições
        public List<ComposicaoDto> Composicoes { get; set; } = new List<ComposicaoDto>();
    }

}
