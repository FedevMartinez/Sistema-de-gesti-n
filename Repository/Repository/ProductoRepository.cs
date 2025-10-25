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
    public class ProductoRepository : IProductRepository
    {
        private readonly SistemaContext _context;

        public ProductoRepository(SistemaContext context)
        {
            _context = context;
        }

        public async Task <Producto> Create(Producto producto)
        {
             _context.Productos.Add(producto);

            await _context.SaveChangesAsync();

            return producto;
        }

        public async Task<IEnumerable<Producto>> Index()
        {
            return await _context.Productos.ToListAsync();
        }
    }
}
