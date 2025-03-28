using Microsoft.EntityFrameworkCore;
using PharmaAPI.Domain.Entities;

namespace PharmaAPI.Infrastructure.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Clientes> Clientes { get; set; }
    public DbSet<ComposicaoMedicamentos> ComposicaoMedicamentos { get; set; }
    public DbSet<ItensPedido> ItensPedido { get; set; }
    public DbSet<MateriasPrimas> MateriasPrimas { get; set; }
    public DbSet<Medicamentos> Medicamentos { get; set; }
    public DbSet<Pedidos> Pedidos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);        

        // Configuração de Medicamento
        modelBuilder.Entity<Medicamentos>()
            .Property(m => m.Preco)
            .HasColumnType("decimal(18,2)");

        // Configuração de Composição de Medicamentos (M:N entre Medicamento e MateriaPrima)
        modelBuilder.Entity<ComposicaoMedicamentos>()
            .HasOne(cm => cm.Medicamento)
            .WithMany(m => m.Composicoes)
            .HasForeignKey(cm => cm.MedicamentoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ComposicaoMedicamentos>()
            .HasOne(cm => cm.MateriasPrimas)
            .WithMany(mp => mp.Composicoes)
            .HasForeignKey(cm => cm.MateriaPrimaId)
            .OnDelete(DeleteBehavior.Cascade);

        // Configuração de Cliente
        modelBuilder.Entity<Clientes>()
            .HasIndex(c => c.CPF)
            .IsUnique();

        modelBuilder.Entity<Clientes>()
            .HasIndex(c => c.Email)
            .IsUnique();

        // Configuração de Pedido
        modelBuilder.Entity<Pedidos>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Pedidos>()
            .Property(p => p.ValorTotal)
            .HasColumnType("decimal(18,2)");

        // Configuração de ItensPedido (M:N entre Pedido e Medicamento)
        modelBuilder.Entity<ItensPedido>()
            .HasOne(ip => ip.Pedido)
            .WithMany(p => p.ItensPedido)
            .HasForeignKey(ip => ip.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItensPedido>()
            .HasOne(ip => ip.Medicamento)
            .WithMany(m => m.ItensPedido)
            .HasForeignKey(ip => ip.MedicamentoId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ItensPedido>()
            .Property(ip => ip.PrecoUnitario)
            .HasColumnType("decimal(18,2)");
    }   
}