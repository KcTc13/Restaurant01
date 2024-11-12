using System.ComponentModel.DataAnnotations;

namespace Restauranteprueba.Models
{
    public class Menu
    {
        [Key]
        public int IdPlatillo { get; set; }

        [Required, StringLength(80)]
        public string NombrePlatillo { get; set; }

        [Required, StringLength(255)]
        public string Descripcion { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        public decimal Precio { get; set; }
        //Relación uno a muchos con `DetalleOrdenes` (Un platillo puede estar en varios detalles de órdenes).
//Relación uno a uno con `CategoriaMenu` (Cada platillo tiene una sola categoría, y cada categoría pertenece a un platillo).
    }
}
