using AutoMapper;
using Models.Entities;
using Repositories.Interface;
using SistemaGestion;
using SistemaGestion.Utils;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Services.Services
{
    public class ClienteProveedorService
    {
        private readonly IClienteProveedorRepository _clienteProveedorRepository;
        private readonly IMapper _mapper;

        public ClienteProveedorService(IClienteProveedorRepository clienteProveedorRepository, IMapper mapper)
        {
            _clienteProveedorRepository = clienteProveedorRepository;
            _mapper = mapper;
        }

        // Obtener todos
        public async Task<IEnumerable<ClienteProveedorViewModel>> GetAllAsync()
        {
            var lista = await _clienteProveedorRepository.IndexAsync();
            return _mapper.Map<List<ClienteProveedorViewModel>>(lista);
        }

        // Obtener por Id
        public async Task<ClienteProveedorViewModel?> GetByIdAsync(int id)
        {
            var entidad = await _clienteProveedorRepository.GetByIdAsync(id);
            return _mapper.Map<ClienteProveedorViewModel>(entidad);
        }

        // Crear
        public async Task<ClienteProveedor> CreateAsync(ClienteProveedorViewModel model)
        {
            var entidad = _mapper.Map<ClienteProveedor>(model);
            return await _clienteProveedorRepository.AddAsync(entidad);
        }

        // Actualizar
        public async Task<ClienteProveedorViewModel> UpdateAsync(ClienteProveedorViewModel model)
        {
            var entidad = _mapper.Map<ClienteProveedor>(model);
            var actualizado = await _clienteProveedorRepository.UpdateAsync(entidad);

            return _mapper.Map<ClienteProveedorViewModel>(actualizado);
        }

        // Eliminar
        public async Task DeleteAsync(int id)
        {
            await _clienteProveedorRepository.DeleteAsync(id);
        }
    }
}
