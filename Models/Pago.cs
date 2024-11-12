using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restauranteprueba.Models
{
	public class Pago
	{
		[Key]
		public int IdPago { get; set; }

		[ForeignKey("Orden")]
		public int IdOrden { get; set; }

		[Required, StringLength(50)]
		[RegularExpression(@"^(Tarjeta de crédito|Efectivo)$", ErrorMessage = "El método de pago debe ser 'Tarjeta de crédito' o 'Efectivo'.")]
		public string MetodoPago { get; set; }

		[Required]
		[Range(0, double.MaxValue, ErrorMessage = "El monto pagado debe ser mayor a 0.")]
		public decimal MontoPagado { get; set; }

		[Required]
		[DataType(DataType.DateTime)]
		public DateTime FechaPago { get; set; }

		public virtual Orden Orden { get; set; }
		//Relación uno a uno con `Ordenes` (Cada orden tiene un pago).
	}
}
