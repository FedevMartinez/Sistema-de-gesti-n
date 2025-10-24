using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class SubCategoria
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Codigo { get; set; }

    public int CategoriaId { get; set; }

    public virtual Categoria Categoria { get; set; } = null!;

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
