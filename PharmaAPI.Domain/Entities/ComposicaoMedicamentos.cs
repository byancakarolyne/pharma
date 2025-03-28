using PharmaAPI.Domain.Entities;
using System.Text.Json.Serialization;

public class ComposicaoMedicamentos
{
    public int Id { get; set; }
    public int MedicamentoId { get; set; }
    [JsonIgnore]
    public Medicamentos? Medicamento { get; set; }

    public int MateriaPrimaId { get; set; }
    
    public MateriasPrimas? MateriasPrimas { get; set; }

    public int QuantidadeUtilizada { get; set; }
}
