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

        public async Task <Producto> AddAsync(Producto producto)
        {
             _context.Productos.Add(producto);

            await _context.SaveChangesAsync();

            return producto;
        }
        public async Task<Producto> UpdateAsync(Producto producto)
        {
            // Buscar el producto existente desde el contexto (ya trackeado)
            var existente = await _context.Productos.FindAsync(producto.Id);
            if (existente == null)
                throw new Exception($"No se encontró el producto con Id {producto.Id}");

            // Actualizar campos manualmente
            existente.Descripcion = producto.Descripcion;
            existente.CostoPesos = producto.CostoPesos;
            existente.CostoDolar = producto.CostoDolar;
            existente.ValorPesos = producto.ValorPesos;
            existente.ValorDolar = producto.ValorDolar;
            existente.FechaCompra = producto.FechaCompra;
            existente.ValorDolarMomentoCompra = producto.ValorDolarMomentoCompra;
            existente.FechaIngreso = producto.FechaIngreso;
            existente.Cantidad = producto.Cantidad;
            existente.ClienteProveedorId = producto.ClienteProveedorId;
            existente.SubCategoriaId = producto.SubCategoriaId;

            await _context.SaveChangesAsync();
            return existente;
        }



        public async Task<IEnumerable<Producto>> IndexAsync()
        {
            return await _context.Productos.ToListAsync();
        }

        public async Task<Producto?> GetByIdAsync(int id)
        {
            return await _context.Productos
                .AsNoTracking() // 👈 importantísimo para evitar el tracking doble
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
                throw new Exception($"No se encontró el producto con Id {id}");

            _context.Productos.Remove(producto);
            await _context.SaveChangesAsync();
        }

    }
}
