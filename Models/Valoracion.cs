using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Restauranteprueba.Models
{
	public class Valoracion
	{
		[Key]
		public int IdValoracion { get; set; }

		[ForeignKey("Cliente")]
		public int IdCliente { get; set; }

		[StringLength(255)]
		public string Comentario { get; set; }

		[Range(1, 5, ErrorMessage = "La puntuación debe estar entre 1 y 5.")]
		public int Puntuacion { get; set; }

		[DataType(DataType.DateTime)]
		public DateTime? FechaValoracion { get; set; }

		public virtual Cliente Cliente { get; set; }
		//Relación muchos a uno con `Clientes` (Un cliente puede hacer varias valoraciones).
	}
}
