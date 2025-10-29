using Models.Entities;

namespace Repositories.Interface
{
    public interface ISubCategoriaRepository
    {
        Task<SubCategoria> AddAsync(SubCategoria subCategoria);
        Task<SubCategoria> UpdateAsync(SubCategoria subCategoria);
        Task<IEnumerable<SubCategoria>> IndexAsync();
        Task<SubCategoria?> GetByIdAsync(int id);
        Task DeleteAsync(int id);
        Task<IEnumerable<SubCategoria>> GetByCategoriaIdAsync(int categoriaId);
    }
}
