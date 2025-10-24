using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace Controllers
{
    internal class ProductoController
    {
        private readonly ProductoService productoService;
        public ProductoController(ProductoService _productoService)
        {
            productoService = _productoService;
        }

        public void Index()
        {
            var lista = productoService.Index();
        }
    }
}
