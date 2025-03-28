using PharmaAPI.Domain.Entities;
using System.Text.Json.Serialization;

public class ItensPedido
{
    public int Id { get; set; }
    public int PedidoId { get; set; }
    public int MedicamentoId { get; set; }
    public int Quantidade { get; set; }
    public decimal PrecoUnitario { get; set; }
    [JsonIgnore]
    public Pedidos? Pedido { get; set; }
    public Medicamentos? Medicamento { get; set; }
}
