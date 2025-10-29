using AutoMapper;
using Models.Entities;
using Repositories.Interface;
using Services.ViewModels;
using SistemaGestion.Utils;

namespace Services.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository _categoriaRepository;
        private readonly IMapper _mapper;

        public CategoriaService(ICategoriaRepository categoriaRepository, IMapper mapper)
        {
            _categoriaRepository = categoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoriaViewModel>> GetAllAsync()
        {
            var lista = await _categoriaRepository.IndexAsync();
            var listaMapeada = _mapper.Map<List<CategoriaViewModel>>(lista);
            return listaMapeada;
        }

        public async Task<Categoria> CreateAsync(CategoriaViewModel model)
        {
            var categoria = _mapper.Map<Categoria>(model);
            return await _categoriaRepository.AddAsync(categoria);
        }

        public async Task<CategoriaViewModel> UpdateAsync(CategoriaViewModel model)
        {
            var categoria = _mapper.Map<Categoria>(model);
            var actualizada = await _categoriaRepository.UpdateAsync(categoria);
            return _mapper.Map<CategoriaViewModel>(actualizada);
        }

        public async Task DeleteAsync(int id)
        {
            await _categoriaRepository.DeleteAsync(id);
        }

        public async Task<CategoriaViewModel?> GetByIdAsync(int id)
        {
            var categoria = await _categoriaRepository.GetByIdAsync(id);
            return _mapper.Map<CategoriaViewModel?>(categoria);
        }
    }
}
