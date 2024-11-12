using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restauranteprueba.Models
{
    public class Inventario
    {
        [Key]
        public int IdInventario { get; set; }

        [ForeignKey("Ingrediente")]
        public int IdIngrediente { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "La cantidad disponible debe ser mayor o igual a 0.")]
        public int CantidadDisponible { get; set; }

        public virtual Ingrediente Ingrediente { get; set; }
        //-- Relación muchos a uno con `Ingredientes` (Un registro del inventario pertenece a un solo ingrediente).
    }
}
