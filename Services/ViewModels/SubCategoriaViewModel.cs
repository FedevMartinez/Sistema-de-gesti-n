using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.ViewModels
{
    public class CategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres")]
        public string Descripcion { get; set; }

        [StringLength(20, ErrorMessage = "El código no puede tener más de 20 caracteres")]
        public string? Codigo { get; set; }

        // Si querés manejar las subcategorías dentro del mismo formulario
        // podrías agregar esta propiedad, aunque no suele enviarse en un ABM simple
        public List<int>? SubCategoriaIds { get; set; }
    }
}
