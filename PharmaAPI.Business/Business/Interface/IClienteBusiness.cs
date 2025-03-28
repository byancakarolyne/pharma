using PharmaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaAPI.Business.Business.Interface
{
    public interface IClienteBusiness
    {
        Task<int> Create(Clientes request);
        Task<List<Clientes>> GetAll();
        Task<Clientes> GetById(int id);
        Task<Clientes> Update(int id, Clientes request);
        Task<bool> Delete(int id);
    }
}
