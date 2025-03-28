using Microsoft.EntityFrameworkCore;
using PharmaAPI.Business.Business.Interface;
using PharmaAPI.Infrastructure.Data;

namespace PharmaAPI.Business.Business
{
    public class PedidoBusiness : IPedidoBusiness
    {
        private readonly AppDbContext _context;

        public PedidoBusiness(AppDbContext context) => _context = context;

        public async Task<int> Create(Pedidos request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {                
                var pedido = new Pedidos
                {
                    ClienteId = request.ClienteId,
                    ValorTotal = request.ValorTotal,
                    ItensPedido = new List<ItensPedido>(),
                };

                _context.Pedidos.Add(pedido);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return pedido.Id;

                throw new NotImplementedException();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }       

        public async Task<int> CadastrarPedido(Pedidos request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var Pedido = new Pedidos
                {
                    Cliente = request.Cliente,
                    DataPedido = request.DataPedido,
                    ClienteId = request.ClienteId,
                    ItensPedido = new List<ItensPedido>(),
                    ValorTotal = request.ValorTotal
                };

                foreach (var item in request.ItensPedido)
                {
                    Pedido.ItensPedido.Add(new ItensPedido
                    {
                        MedicamentoId = item.MedicamentoId,
                        Quantidade = item.Quantidade
                    });
                };
                

                _context.Pedidos.Add(Pedido);
                await _context.SaveChangesAsync();
               
                await transaction.CommitAsync();

                return Pedido.Id;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Pedidos>> GetAll()
        {
            try
            {
                return await _context.Pedidos.ToListAsync();    
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

        public async Task<Pedidos> GetById(int id)
        {
            try
            {
                return await _context.Pedidos
                        .Include(c => c.Cliente)
                        .Include(ip => ip.ItensPedido)
                            .ThenInclude(m => m.Medicamento)
                            .ThenInclude(c => c.Composicoes)
                                .ThenInclude(mp => mp.MateriasPrimas)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Pedidos> Update(int id, Pedidos PedidoAtualizado)
        {
            try
            {
                var Pedido = await _context.Pedidos.FindAsync(id);

                if (Pedido == null)
                {
                    return null;
                }
                

                await _context.SaveChangesAsync();

                return Pedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Delete(int id)
        {
            try
            {
                var Pedido = await _context.Pedidos.FindAsync(id);

                if (Pedido == null)
                {
                    return false;
                }

                _context.Pedidos.Remove(Pedido);

                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
