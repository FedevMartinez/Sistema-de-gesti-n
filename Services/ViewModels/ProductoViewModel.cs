using System.ComponentModel.DataAnnotations;

namespace SistemaGestion
{
    public class ProductoViewModel
    {
        [Required(ErrorMessage = "La descripción es obligatoria")]
        public string Descripcion { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public int? Cantidad { get; set; }

        [Required(ErrorMessage = "Fecha de ingreso es obligatoria")]
        public DateTime? FechaIngreso { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El costo en pesos debe ser mayor a 0")]
        public decimal? CostoPesos { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El costo en dólares debe ser mayor a 0")]
        public decimal? CostoDolar { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El valor en pesos debe ser mayor a 0")]
        public decimal? ValorPesos { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El valor en dólares debe ser mayor a 0")]
        public decimal? ValorDolar { get; set; }

        public DateTime? FechaCompra { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "El valor del dólar al momento debe ser mayor a 0")]
        public decimal? ValorDolarMomentoCompra { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una subcategoría")]
        public int? SubCategoriaId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar un cliente/proveedor")]
        public int? ClienteProveedorId { get; set; }
    }

}
