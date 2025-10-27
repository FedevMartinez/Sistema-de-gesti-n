using System.ComponentModel.DataAnnotations;

namespace SistemaGestion
{
public class ProductoViewModel
    {
        [StringLength(6)]
        public string Descripcion { get; set; }

        public decimal? CostoPesos { get; set; }

        public decimal? CostoDolar { get; set; }

        public decimal? ValorPesos { get; set; }

        public decimal? ValorDolar { get; set; }

        public DateTime? FechaCompra { get; set; }

        public decimal? ValorDolarMomentoCompra { get; set; }

        public DateTime? FechaIngreso { get; set; }

        public int? ClienteProveedorId { get; set; }

        public int? SubCategoriaId { get; set; }

        public int? Cantidad { get; set; }
        
    }
}
