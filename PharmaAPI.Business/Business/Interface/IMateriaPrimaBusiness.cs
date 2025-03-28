using PharmaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaAPI.Business.Business.Interface
{
    public interface IMateriaPrimaBusiness
    {
        Task<int> Create(MateriasPrimas request);
        Task<List<MateriasPrimas>> GetAll();
        Task<MateriasPrimas> GetById(int id);
        Task<MateriasPrimas> Update(int id, MateriasPrimas request);
        Task<bool> Delete(int id);
    }
}
