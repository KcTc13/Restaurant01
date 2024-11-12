using System.ComponentModel.DataAnnotations;

namespace Restauranteprueba.Models
{
    public class Mesa
    {
        [Key]
        public int IdMesa { get; set; }

        [Required]
        public int NumeroMesa { get; set; }

        [Required]
        public int Capacidad { get; set; }

        [Required, StringLength(20)]
        [RegularExpression(@"^(Libre|Ocupada|Reservada)$", ErrorMessage = "El estado debe ser 'Libre', 'Ocupada' o 'Reservada'.")]
        public string Estado { get; set; }
        // Relación uno a muchos con `Ordenes` (Una mesa puede tener varias órdenes a lo largo del tiempo).
        //Relación uno a muchos con `Reservas` (Una mesa puede tener varias reservas a lo largo del tiempo).
    }
}
