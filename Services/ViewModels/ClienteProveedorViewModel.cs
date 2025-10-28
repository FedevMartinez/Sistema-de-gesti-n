using System;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestion.Utils
{
    public class ClienteProveedorViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres")]
        public string? Nombre { get; set; }

        [StringLength(100, ErrorMessage = "El apellido no puede superar los 100 caracteres")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "La razón social es obligatoria")]
        [StringLength(150, ErrorMessage = "La razón social no puede superar los 150 caracteres")]
        public string? RazonSocial { get; set; }

        [Required(ErrorMessage = "El CUIT es obligatorio")]
        [RegularExpression(@"^\d{2}-\d{8}-\d{1}$", ErrorMessage = "El CUIT debe tener el formato XX-XXXXXXXX-X")]
        public string? Cuit { get; set; }

        [Phone(ErrorMessage = "El teléfono no tiene un formato válido")]
        [StringLength(20, ErrorMessage = "El teléfono no puede superar los 20 caracteres")]
        public string? Telefono { get; set; }

        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido")]
        [StringLength(150, ErrorMessage = "El correo electrónico no puede superar los 150 caracteres")]
        public string? Email { get; set; }

        [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres")]
        public string? Direccion { get; set; }

        [StringLength(100, ErrorMessage = "La localidad no puede superar los 100 caracteres")]
        public string? Localidad { get; set; }

        [StringLength(100, ErrorMessage = "La provincia no puede superar los 100 caracteres")]
        public string? Provincia { get; set; }

        [StringLength(10, ErrorMessage = "El código postal no puede superar los 10 caracteres")]
        public string? CodigoPostal { get; set; }

        [Required(ErrorMessage = "La fecha de alta es obligatoria")]
        [DataType(DataType.Date, ErrorMessage = "La fecha de alta no tiene un formato válido")]
        public DateTime? FechaAlta { get; set; }
    }
}
