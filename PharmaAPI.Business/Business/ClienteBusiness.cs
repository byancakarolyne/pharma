using Microsoft.EntityFrameworkCore;
using PharmaAPI.Business.Business.Interface;
using PharmaAPI.Infrastructure.Data;

namespace PharmaAPI.Business.Business
{
    public class ClienteBusiness : IClienteBusiness
    {
        private readonly AppDbContext _context;

        public ClienteBusiness(AppDbContext context) => _context = context;

        public async Task<int> Create(Clientes request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var cliente = new Clientes
                {
                    Nome = request.Nome,
                    CPF = request.CPF,
                    Endereco = request.Endereco,
                    Email = request.Email,
                    Telefone = request.Telefone,
                };

                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return cliente.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }       

        public async Task<List<Clientes>> GetAll()
        {
            try
            {
                return await _context.Clientes.ToListAsync();    
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

        public async Task<Clientes> GetById(int id)
        {
            try
            {
                return await _context.Clientes
                    .Include(p => p.Pedidos)
                            .ThenInclude(ip => ip.ItensPedido)
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Clientes> Update(int id, Clientes ClienteAtualizado)
        {
            try
            {
                var Cliente = await _context.Clientes.FindAsync(id);

                if (Cliente == null)
                {
                    return null;
                }

                Cliente.Nome = ClienteAtualizado.Nome;
                Cliente.Endereco = ClienteAtualizado.Endereco;
                Cliente.CPF = ClienteAtualizado.CPF;
                Cliente.Telefone = ClienteAtualizado.Telefone;
                Cliente.Email = ClienteAtualizado.Email;
                Cliente.Pedidos = ClienteAtualizado.Pedidos;

                await _context.SaveChangesAsync();

                return Cliente;
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
                var Cliente = await _context.Clientes.FindAsync(id);

                if (Cliente == null)
                {
                    return false;
                }

                _context.Clientes.Remove(Cliente);

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
