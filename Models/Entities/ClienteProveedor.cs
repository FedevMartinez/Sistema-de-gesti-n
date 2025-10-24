using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class ClienteProveedor
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellido { get; set; }

    public string? RazonSocial { get; set; }

    public string? Cuit { get; set; }

    public string? Telefono { get; set; }

    public string? Email { get; set; }

    public string? Direccion { get; set; }

    public string? Localidad { get; set; }

    public string? Provincia { get; set; }

    public string? CodigoPostal { get; set; }

    public DateTime? FechaAlta { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
