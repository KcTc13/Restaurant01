using Microsoft.EntityFrameworkCore;
using Restauranteprueba.Models;

namespace Restauranteprueba.Datos
{
	public class AplicationDbContext : DbContext
	{
		//constructor
		public AplicationDbContext(DbContextOptions<AplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Cliente> Cliente { get; set; }
		public DbSet<Empleado> Empleado { get; set; }
		public DbSet<Mesa> Mesa { get; set; }
		public DbSet<Menu> Menu { get; set; }
		public DbSet<CategoriaMenu> CategoriaMenu { get; set; }
		public DbSet<Orden> Orden { get; set; }

		public DbSet<DetalleOrden> DetalleOrden { get; set; }
		public DbSet<Reserva> Reserva { get; set; }
		public DbSet<Pago> Pago { get; set; }
		public DbSet<Valoracion> Valoracion { get; set; }
		public DbSet<Ingrediente> Ingrediente { get; set; }
		public DbSet<Inventario> Inventario { get; set; }


	}
}
