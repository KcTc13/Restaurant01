using System.ComponentModel.DataAnnotations;

namespace Restauranteprueba.Models
{
    public class Ingrediente
    {
        [Key]
        public int IdIngrediente { get; set; }

        [Required, StringLength(80)]
        public string NombreIngrediente { get; set; }
        //-- Relación uno a muchos con `Inventario` (Un ingrediente puede estar presente en varios registros del inventario).
    }
}
