using Microsoft.EntityFrameworkCore;
using Models.Context;
using Models.Entities;
using Repositories.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Repository
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly SistemaContext _context;

        public CategoriaRepository(SistemaContext context)
        {
            _context = context;
        }

        public async Task<Categoria> AddAsync(Categoria categoria)
        {
            _context.Set<Categoria>().Add(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<Categoria> UpdateAsync(Categoria categoria)
        {
            // Verifica si ya hay una instancia con el mismo Id en el contexto
            var local = _context.Set<Categoria>()
                .Local
                .FirstOrDefault(entry => entry.Id == categoria.Id);

            // Si existe, la desadjunta (para evitar el error de tracking duplicado)
            if (local != null)
                _context.Entry(local).State = EntityState.Detached;

            // Limpia la navegación para evitar que intente guardar subcategorías
            categoria.SubCategoria = null;

            _context.Set<Categoria>().Update(categoria);
            await _context.SaveChangesAsync();
            return categoria;
        }

        public async Task<IEnumerable<Categoria>> IndexAsync()
        {
            return await _context.Set<Categoria>()
                .AsNoTracking()
                .Include(c => c.SubCategoria)
                .ToListAsync();
        }

        public async Task<Categoria?> GetByIdAsync(int id)
        {
            return await _context.Set<Categoria>()
                .AsNoTracking()
                .Include(c => c.SubCategoria)
                .FirstOrDefaultAsync(c => c.Id == id);
        }


        public async Task DeleteAsync(int id)
        {
            var categoria = await _context.Set<Categoria>().FindAsync(id);
            if (categoria != null)
            {
                _context.Set<Categoria>().Remove(categoria);
                await _context.SaveChangesAsync();
            }
        }
    }
}
