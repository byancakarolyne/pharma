using PharmaAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PharmaAPI.Business.Business.Interface
{
    public interface IPedidoBusiness
    {
        Task<int> Create(Pedidos request);        
        Task<List<Pedidos>> GetAll();
        Task<Pedidos> GetById(int id);
        Task<Pedidos> Update(int id, Pedidos request);
        Task<bool> Delete(int id);
    }
}
