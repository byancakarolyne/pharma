public class Pedidos
{
    public int Id { get; set; }
    public int ClienteId { get; set; }
    public DateTime DataPedido { get; set; } = DateTime.Now;
    public decimal ValorTotal { get; set; }
    public Clientes? Cliente { get; set; }
    public ICollection<ItensPedido> ItensPedido { get; set; }
}
