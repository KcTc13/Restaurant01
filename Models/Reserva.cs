using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Restauranteprueba.Models
{
	public class Reserva
	{
		[Key]
		public int IdReserva { get; set; }

		[ForeignKey("Cliente")]
		public int IdCliente { get; set; }

		[ForeignKey("Mesa")]
		public int IdMesa { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime FechaHoraReserva { get; set; }

		[Required, StringLength(20)]
		[RegularExpression(@"^(Confirmada|Pendiente|Cancelada)$", ErrorMessage = "El estado de la reserva debe ser 'Confirmada', 'Pendiente' o 'Cancelada'.")]
		public string EstadoReserva { get; set; }

		public virtual Cliente Cliente { get; set; }
		public virtual Mesa Mesa { get; set; }
		// Relación muchos a uno con `Clientes` (Un cliente puede hacer varias reservas).
		//Relación muchos a uno con `Mesas` (Una mesa puede tener varias reservas a lo largo del tiempo).
	}
}
