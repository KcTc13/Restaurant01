using System.ComponentModel.DataAnnotations;
using System.Runtime.ConstrainedExecution;

namespace Restauranteprueba.Models
{
	public class Cliente
	{
		[Key]
		public int IdCliente { get; set; }

		[Required, StringLength(80)]
		public string Nombres { get; set; }

		[Required, StringLength(80)]
		public string Apellidos { get; set; }

		[Required, StringLength(10)]
		[RegularExpression(@"^\d{10}$", ErrorMessage = "El número de celular debe tener 10 dígitos.")]
		public string Celular { get; set; }

		[Required, StringLength(80)]
		[RegularExpression(@"^[^ ,;]+@[^ ,;]+.[^ ,;]+$", ErrorMessage = "El correo no es válido.")]
		public string Correo { get; set; }

		[Required, StringLength(40)]
		public string Ciudad { get; set; }
		//Relación uno a muchos con Ordenes (Un cliente puede hacer varias órdenes).
		//Relación uno a muchos con Reservas (Un cliente puede hacer varias reservas).
		//Relación uno a muchos con Valoraciones (Un cliente puede realizar varias valoraciones).
	}
}