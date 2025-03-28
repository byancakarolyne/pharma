using System.Text.Json.Serialization;

public class Clientes
{
    public int Id { get; set; }
    public string Nome { get; set; }
    private string _cpf;
    public string CPF
    {
        get => _cpf;
        set => _cpf = value?.Replace(".", "").Replace("-", "");  
    }
    public string Endereco { get; set; }
    private string _telefone;
    public string Telefone
    {
        get => _telefone;
        set => _telefone = new string(value?.Where(char.IsDigit).ToArray()); // Mantém apenas os números
    }
    public string Email { get; set; }
    [JsonIgnore]
    public ICollection<Pedidos>? Pedidos { get; set; }
}
