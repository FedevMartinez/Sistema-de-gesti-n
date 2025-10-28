using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Repositories.Interface
{
    public interface IClienteProveedorRepository
    {
        Task<ClienteProveedor> AddAsync(ClienteProveedor ClienteProveedor);
        Task<ClienteProveedor> UpdateAsync(ClienteProveedor ClienteProveedor);
        Task<IEnumerable<ClienteProveedor>> IndexAsync();
        Task<ClienteProveedor> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
