using System;
using System.Collections.Generic;

namespace Models.Entities;

public partial class Categoria
{
    public int Id { get; set; }

    public string Descripcion { get; set; } = null!;

    public string? Codigo { get; set; }

    public virtual ICollection<SubCategoria> SubCategoria { get; set; } = new List<SubCategoria>();
}
