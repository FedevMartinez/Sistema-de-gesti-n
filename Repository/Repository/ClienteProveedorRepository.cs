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
    public class ClienteProveedorRepository : IClienteProveedorRepository
    {
        private readonly SistemaContext _context;

        public ClienteProveedorRepository(SistemaContext context)
        {
            _context = context;
        }

        public async Task <ClienteProveedor> AddAsync(ClienteProveedor clienteProveedor)
        {
             _context.ClienteProveedors.Add(clienteProveedor);

            await _context.SaveChangesAsync();

            return clienteProveedor;
        }
        public async Task<ClienteProveedor> UpdateAsync(ClienteProveedor clienteProveedor)
        {
            // Buscar el clienteProveedor existente desde el contexto (ya trackeado)
            var existente = await GetByIdAsync(clienteProveedor.Id);
            if (existente == null)
                throw new Exception($"No se encontró el clienteProveedor con Id {clienteProveedor.Id}");

            // Actualizar campos manualmente
            existente.Nombre = clienteProveedor.Nombre;
            existente.Apellido = clienteProveedor.Apellido;
            existente.RazonSocial = clienteProveedor.RazonSocial;
            existente.Cuit = clienteProveedor.Cuit;
            existente.Telefono = clienteProveedor.Telefono;
            existente.Email = clienteProveedor.Email;
            existente.Direccion = clienteProveedor.Direccion;
            existente.Localidad = clienteProveedor.Localidad;
            existente.Provincia = clienteProveedor.Provincia;
            existente.CodigoPostal = clienteProveedor.CodigoPostal;
            existente.FechaAlta = clienteProveedor.FechaAlta;
            
            //Se podría usar la clase AutoMapping pero esta en services


            await _context.SaveChangesAsync();
            return existente;
        }



        public async Task<IEnumerable<ClienteProveedor>> IndexAsync()
        {
            return await _context.ClienteProveedors.ToListAsync();
        }

        public async Task<ClienteProveedor?> GetByIdAsync(int id)
        {
            return await _context.ClienteProveedors
                .FirstOrDefaultAsync(p => p.Id == id);
        }


        public async Task DeleteAsync(int id)
        {
            var clienteProveedor = await GetByIdAsync(id);
            if (clienteProveedor == null)
                throw new Exception($"No se encontró el clienteProveedor con Id {id}");

            _context.ClienteProveedors.Remove(clienteProveedor);
            await _context.SaveChangesAsync();
        }

    }
}
