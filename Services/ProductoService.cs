using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.Entities;
using Repositories.Interface;
using Sistema_de_gestión;

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

        public List<ProductoViewModel> Index()
        {
            var lista = _productRepository.Index();

            return _mapper.Map<List<ProductoViewModel>>(lista);


        }
    }
}
