using AutoMapper;
using Models.Entities;
using Repositories.Interface;
using SistemaGestion.Utils;

namespace Services.Services
{
    public class SubCategoriaService
    {
        private readonly ISubCategoriaRepository _subCategoriaRepository;
        private readonly IMapper _mapper;

        public SubCategoriaService(ISubCategoriaRepository subCategoriaRepository, IMapper mapper)
        {
            _subCategoriaRepository = subCategoriaRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<SubCategoriaViewModel>> GetAllAsync()
        {
            var lista = await _subCategoriaRepository.IndexAsync();
            return _mapper.Map<List<SubCategoriaViewModel>>(lista);
        }

        public async Task<IEnumerable<SubCategoriaViewModel>> GetByCategoriaIdAsync(int categoriaId)
        {
            var lista = await _subCategoriaRepository.GetByCategoriaIdAsync(categoriaId);
            return _mapper.Map<List<SubCategoriaViewModel>>(lista);
        }

        public async Task<SubCategoria> CreateAsync(SubCategoriaViewModel model)
        {
            var entidad = _mapper.Map<SubCategoria>(model);
            return await _subCategoriaRepository.AddAsync(entidad);
        }

        public async Task<SubCategoriaViewModel> UpdateAsync(SubCategoriaViewModel model)
        {
            var entidad = _mapper.Map<SubCategoria>(model);
            var actualizada = await _subCategoriaRepository.UpdateAsync(entidad);
            return _mapper.Map<SubCategoriaViewModel>(actualizada);
        }

        public async Task DeleteAsync(int id)
        {
            await _subCategoriaRepository.DeleteAsync(id);
        }

        public async Task<SubCategoriaViewModel?> GetByIdAsync(int id)
        {
            var entidad = await _subCategoriaRepository.GetByIdAsync(id);
            return _mapper.Map<SubCategoriaViewModel?>(entidad);
        }
    }
}
