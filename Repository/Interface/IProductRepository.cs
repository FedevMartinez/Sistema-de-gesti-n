using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Repositories.Interface
{
    public interface IProductRepository
    {
        Task<Producto> AddAsync(Producto producto);
        Task<Producto> UpdateAsync(Producto producto);
        Task<IEnumerable<Producto>> IndexAsync();
        Task<Producto> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
