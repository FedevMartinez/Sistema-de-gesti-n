using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Utils
{
    public class SubCategoriaViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [StringLength(100, ErrorMessage = "La descripción no puede tener más de 100 caracteres")]
        public string Descripcion { get; set; }

        [StringLength(20, ErrorMessage = "El código no puede tener más de 20 caracteres")]
        public string? Codigo { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar una categoría")]
        public int CategoriaId { get; set; }
    }
}
