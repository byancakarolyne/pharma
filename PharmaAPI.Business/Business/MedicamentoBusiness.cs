using Microsoft.EntityFrameworkCore;
using PharmaAPI.Business.Business.Interface;
using PharmaAPI.Domain.Entities;
using PharmaAPI.Infrastructure.Data;

namespace PharmaAPI.Business.Business
{
    public class MedicamentoBusiness : IMedicamentoBusiness
    {
        private readonly AppDbContext _context;

        public MedicamentoBusiness(AppDbContext context) => _context = context;       

        public async Task<int> Create(Medicamentos request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var medicamento = new Medicamentos
                {
                    Nome = request.Nome,
                    Descricao = request.Descricao,
                    Preco = request.Preco,
                    QuantidadeEmEstoque = request.QuantidadeEmEstoque
                };

                _context.Medicamentos.Add(medicamento);
                await _context.SaveChangesAsync();

                // Vincular matérias-primas ao medicamento
                foreach (var composicao in request.Composicoes)
                {
                    var composicaoMedicamento = new ComposicaoMedicamentos
                    {
                        MedicamentoId = medicamento.Id,  
                        MateriaPrimaId = composicao.MateriaPrimaId,
                        QuantidadeUtilizada = composicao.QuantidadeUtilizada
                    };
                    _context.ComposicaoMedicamentos.Add(composicaoMedicamento);
                }

                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return medicamento.Id;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<List<Medicamentos>> GetAll()
        {
            try
            {
                return await _context.Medicamentos.ToListAsync();    
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

        public async Task<Medicamentos> GetById(int id)
        {
            try
            {
                return await _context.Medicamentos
                    .Include(m => m.Composicoes) 
                        .ThenInclude(c => c.MateriasPrimas) 
                    .FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Medicamentos> Update(int id, Medicamentos medicamentoAtualizado)
        {
            try
            {
                var medicamento = await _context.Medicamentos.FindAsync(id);

                if (medicamento == null)
                {
                    return null;
                }

                medicamento.Nome = medicamentoAtualizado.Nome;
                medicamento.Descricao = medicamentoAtualizado.Descricao ?? medicamento.Descricao;
                medicamento.Preco = medicamentoAtualizado.Preco;
                medicamento.Composicoes = medicamentoAtualizado.Composicoes;
                medicamento.QuantidadeEmEstoque = medicamentoAtualizado.QuantidadeEmEstoque;

                await _context.SaveChangesAsync();

                return medicamento;
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
                var medicamento = await _context.Medicamentos.FindAsync(id);

                if (medicamento == null)
                {
                    return false;
                }

                _context.Medicamentos.Remove(medicamento);

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
