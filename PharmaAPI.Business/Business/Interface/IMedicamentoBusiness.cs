using PharmaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaAPI.Business.Business.Interface
{
    public interface IMedicamentoBusiness
    {
        Task<int> Create(Medicamentos request);
        Task<List<Medicamentos>> GetAll();
        Task<Medicamentos> GetById(int id);
        Task<Medicamentos> Update(int id, Medicamentos request);
        Task<bool> Delete(int id);
    }
}
