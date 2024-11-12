using System.ComponentModel.DataAnnotations;

namespace Restauranteprueba.Models
{
    public class Empleado
    {
        [Key]
        public int IdEmpleado { get; set; }

        [Required, StringLength(80)]
        public string Nombres { get; set; }

        [Required, StringLength(80)]
        public string Apellidos { get; set; }

        [Required, StringLength(90)]
        public string Direccion { get; set; }

        [Required, StringLength(13, MinimumLength = 13)]
        public string Rfc { get; set; }

        [Required, StringLength(50)]
        public string Puesto { get; set; }

        [Required, StringLength(1)]
        [RegularExpression(@"[MF]", ErrorMessage = "El género debe ser 'M' o 'F'.")]
        public string Genero { get; set; }

        [Required, StringLength(5)]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "El código postal debe tener 5 dígitos.")]
        public string CodigoPostal { get; set; }

        [Required, StringLength(1)]
        [RegularExpression(@"[AI]", ErrorMessage = "El estado activo debe ser 'A' o 'I'.")]
        public string Activo { get; set; } = "A";

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El salario no puede ser negativo.")]
        public decimal Salario { get; set; }

        public DateTime? FechaNacimiento { get; set; }
    }
    //Relación uno a muchos con `Ordenes` (Un empleado puede gestionar varias órdenes).
}
