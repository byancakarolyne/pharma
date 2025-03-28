using Microsoft.EntityFrameworkCore;
using PharmaAPI.Business.Business.Interface;
using PharmaAPI.Infrastructure.Data;

namespace PharmaAPI.Business.Business
{
    public class MateriaPrimaBusiness : IMateriaPrimaBusiness
    {
        private readonly AppDbContext _context;

        public MateriaPrimaBusiness(AppDbContext context) => _context = context;

        public async Task<int> Create(MateriasPrimas request)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var materiaPrima = new MateriasPrimas
                {
                    Nome = request.Nome,
                    Descricao = request.Descricao,                     
                    QuantidadeEmEstoque = request.QuantidadeEmEstoque,
                    DataValidade = request.DataValidade
                    
                };

                _context.MateriasPrimas.Add(materiaPrima);
                await _context.SaveChangesAsync();
                await transaction.CommitAsync();

                return materiaPrima.Id;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }   

        public async Task<List<MateriasPrimas>> GetAll()
        {
            try
            {
                return await _context.MateriasPrimas.ToListAsync();    
            }
            catch (Exception ex)
            {
                throw ex;   
            }
        }

        public async Task<MateriasPrimas> GetById(int id)
        {
            try
            {
                return await _context.MateriasPrimas.FirstOrDefaultAsync(m => m.Id == id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MateriasPrimas> Update(int id, MateriasPrimas materiasPrimasAtualizadas)
        {
            try
            {
                var materiaPrima = await _context.MateriasPrimas.FindAsync(id);

                if (materiaPrima == null)
                {
                    return null;
                }

                materiaPrima.Nome = materiasPrimasAtualizadas.Nome;
                materiaPrima.Descricao = materiasPrimasAtualizadas.Descricao ?? materiaPrima.Descricao;
                materiaPrima.QuantidadeEmEstoque = materiasPrimasAtualizadas.QuantidadeEmEstoque;
                materiaPrima.DataValidade = materiasPrimasAtualizadas.DataValidade;               

                await _context.SaveChangesAsync();

                return materiaPrima;
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
                var materiaPrima = await _context.MateriasPrimas.FindAsync(id);

                if (materiaPrima == null)
                {
                    return false;
                }

                _context.MateriasPrimas.Remove(materiaPrima);

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
