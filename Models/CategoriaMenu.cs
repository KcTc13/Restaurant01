using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restauranteprueba.Models
{
    public class CategoriaMenu
    {
        [Key]
        public int IdCategoria { get; set; }

        [ForeignKey("Menu")]
        public int IdPlatillo { get; set; }

        [Required, StringLength(80)]
        public string NombreCategoria { get; set; }

        public virtual Menu Menu { get; set; }
        // Relación uno a uno con `Menus` (Cada categoría pertenece a un solo platillo).
    }
}
