using System.Text.Json.Serialization;

public class MateriasPrimas
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int QuantidadeEmEstoque { get;set; }
    public DateOnly DataValidade { get; set; }    
    
    // Relacionamento com Medicamento_MateriaPrima
    [JsonIgnore]
    public ICollection<ComposicaoMedicamentos>? Composicoes { get; set; }
}
