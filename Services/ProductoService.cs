using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Models.Entities;
using Repositories.Interface;
using SistemaGestion;
using static System.Net.WebRequestMethods;

namespace Services
{
    public class ProductoService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private readonly HttpClient _http;

        public ProductoService(IProductRepository productRepository, IMapper mapper, HttpClient http)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _http = http;
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
        public async Task<ProductoViewModel> UpdateAsync(ProductoViewModel model)
        {
            // Mapeás el ViewModel a la entidad y la enviás al repo
            var producto = _mapper.Map<Producto>(model);
            var actualizado = await _productRepository.UpdateAsync(producto);

            return _mapper.Map<ProductoViewModel>(actualizado);
        }

        public async Task DeleteAsync(int id)
        {
            await _productRepository.DeleteAsync(id);
        }

        public async Task<DolarData?> GetDolarAsync()
        {
            try
            {
                // Ejemplo: API pública del dólar blue
                var oficialResponse = await _http.GetFromJsonAsync<DolarResponse>("https://dolarapi.com/v1/dolares/oficial");
                var blueResponse = await _http.GetFromJsonAsync<DolarResponse>("https://dolarapi.com/v1/dolares/blue");

                DolarData dolarData = new DolarData
                {
                    CompraBlue = blueResponse.Compra,
                    VentaBlue = blueResponse.Venta,
                    CompraOficial = oficialResponse.Compra,
                    VentaOficial = oficialResponse.Venta,
                };

                return dolarData;
            }
            catch
            {
                return null;
            }
        }
    }
}
