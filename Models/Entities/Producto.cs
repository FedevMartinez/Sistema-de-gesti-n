using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class Producto
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

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

    public virtual ClienteProveedor? ClienteProveedor { get; set; }

    public virtual SubCategoria? SubCategoria { get; set; }
}
