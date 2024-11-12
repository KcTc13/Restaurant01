using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restauranteprueba.Models
{
    public class Orden
    {
        [Key]
        public int IdOrden { get; set; }

        [ForeignKey("Empleado")]
        public int IdEmpleado { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        [ForeignKey("Mesa")]
        public int IdMesa { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime FechaOrden { get; set; }

        [Required, StringLength(20)]
        [RegularExpression(@"^(Pendiente|En proceso|Completada)$", ErrorMessage = "El estado de la orden debe ser 'Pendiente', 'En proceso' o 'Completada'.")]
        public string EstadoOrden { get; set; }

        public virtual Empleado Empleado { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual Mesa Mesa { get; set; }
        //Relación muchos a uno con `Clientes` (Un cliente puede realizar varias órdenes).
// Relación muchos a uno con `Empleados` (Un empleado puede gestionar varias órdenes).
// Relación muchos a uno con `Mesas` (Una mesa puede tener varias órdenes a lo largo del tiempo).
//Relación uno a muchos con `DetalleOrdenes` (Una orden puede tener varios detalles de platillos).

    }
}
