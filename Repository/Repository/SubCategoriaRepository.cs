using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;
using Repositories.Interface;

namespace Repositories
{
    public class SubCategoriaRepository : ISubCategoriaRepository
    {
        private readonly IDbContextFactory<SistemaContext> _contextFactory;

        public SubCategoriaRepository(IDbContextFactory<SistemaContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task<SubCategoria> AddAsync(SubCategoria subCategoria)
        {
            using var context = _contextFactory.CreateDbContext();

            context.Set<SubCategoria>().Add(subCategoria);
            await context.SaveChangesAsync();

            // 🔥 Refresca desde la base el objeto recién insertado (opcional)
            await context.Entry(subCategoria).ReloadAsync();

            return subCategoria;
        }

        public async Task<SubCategoria> UpdateAsync(SubCategoria subCategoria)
        {
            using var context = _contextFactory.CreateDbContext();

            // 🔥 Evita conflictos con instancias previas
            var local = context.Set<SubCategoria>()
                .Local
                .FirstOrDefault(entry => entry.Id == subCategoria.Id);

            if (local != null)
                context.Entry(local).State = EntityState.Detached;

            // 🔥 Evita que EF intente actualizar la categoría
            subCategoria.Categoria = null;

            context.Set<SubCategoria>().Update(subCategoria);
            await context.SaveChangesAsync();

            return subCategoria;
        }

        public async Task<IEnumerable<SubCategoria>> IndexAsync()
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Set<SubCategoria>()
                .Include(s => s.Categoria)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<SubCategoria?> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Set<SubCategoria>()
                .AsNoTracking()
                .Include(s => s.Categoria)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<SubCategoria>> GetByCategoriaIdAsync(int categoriaId)
        {
            using var context = _contextFactory.CreateDbContext();

            return await context.Set<SubCategoria>()
                .Where(s => s.CategoriaId == categoriaId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();

            var sub = await context.Set<SubCategoria>().FindAsync(id);
            if (sub != null)
            {
                context.Set<SubCategoria>().Remove(sub);
                await context.SaveChangesAsync();
            }
        }
    }
}
