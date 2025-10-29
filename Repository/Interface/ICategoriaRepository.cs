using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Entities;

namespace Repositories.Interface
{
    public interface ICategoriaRepository
    {
        Task<Categoria> AddAsync(Categoria categoria);
        Task<Categoria> UpdateAsync(Categoria categoria);
        Task<IEnumerable<Categoria>> IndexAsync();
        Task<Categoria?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
    }
}
