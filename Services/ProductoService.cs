using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.Entities;
using Repositories.Interface;
using SistemaGestion;

namespace Services
{
    public class ProductoService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductoService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductoViewModel>> GetAllAsync()
        {
            var lista = await _productRepository.IndexAsync();

            return _mapper.Map<List<ProductoViewModel>>(lista);
        }

        public async Task<Producto> CreateAsync(ProductoViewModel producto)
        {
            return await _productRepository.AddAsync(_mapper.Map<Producto>(producto));
        }

    }
}
