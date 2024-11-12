using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Azure;

namespace Restauranteprueba.Models
{
    public class DetalleOrden
    {
        [Key]
        public int IdDetalleOrden { get; set; }

        [ForeignKey("Orden")]
        public int IdOrden { get; set; }

        [ForeignKey("Menu")]
        public int IdPlatillo { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "El precio debe ser mayor o igual a 0.")]
        public float PrecioUnitario { get; set; }

        public virtual Orden Orden { get; set; }
        public virtual Menu Menu { get; set; }
        // Relación muchos a uno con `Ordenes` (Una orden puede tener varios detalles).
// Relación muchos a uno con `Menus` (Un platillo puede estar en varios detalles de órdenes).
    }
}
