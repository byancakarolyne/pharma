using System.Text.Json.Serialization;

namespace PharmaAPI.Domain.Entities;

public class Medicamentos
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string? Descricao { get; set; }
    public decimal Preco { get; set; }
    public int QuantidadeEmEstoque { get; set; }      
    public ICollection<ComposicaoMedicamentos>? Composicoes { get; set; }
    [JsonIgnore]
    public ICollection<ItensPedido>? ItensPedido { get; set; }
}


