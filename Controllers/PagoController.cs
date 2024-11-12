using Microsoft.AspNetCore.Mvc;
using Restauranteprueba.Datos;
using Restauranteprueba.Models;

namespace Restauranteprueba.Controllers
{
	public class PagoController : Controller
	{
		public readonly AplicationDbContext _context;

		public PagoController(AplicationDbContext aplicationDb)
		{
			_context = aplicationDb;
		}
		public IActionResult Index()
		{
			List<Pago> ListaPagos = _context.Pago.ToList();
			return View(ListaPagos);
		}
		//Crear uno
		public IActionResult Crear()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Crear(Pago pago)
		{
			if (ModelState.IsValid)
			{
				_context.Pago.Add(pago);
				_context.SaveChanges();
				return RedirectToAction("Index");
			}
			return View("Crear", pago);
		}
		//Crear multiples
		//sobrecargar el metodo
		[HttpGet]
		public IActionResult CrearMultiples()
		{
			return View();
		}

		// Metodo para Crear multiples registros
		[HttpPost]
		public IActionResult CrearMultiples(Pago pago)
		{
			String IdPago = Request.Form["IdPago"];
			String IdOrden = Request.Form["IdOrden"];
			String MetodoPago = Request.Form["MetodoPago"];
			String MontoPagado = Request.Form["MontoPagado"];
			String FechaPago = Request.Form["FechaPago"];

			var listaPagos = IdPago.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Trim())
				.ToList();
			var listaOrden = IdOrden.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Trim())
				.ToList();
			var listaMetodo = MetodoPago.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Trim())
				.ToList();
			var listaMonto = MontoPagado.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Trim())
				.ToList();
			var listaFecha = FechaPago.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
				.Select(x => x.Trim())
				.ToList();

			if (listaPagos.Count == 0 | listaOrden.Count == 0 | listaMetodo.Count == 0 | listaMonto.Count == 0 | listaFecha.Count == 0)
			{
				return CrearMultiples();
			}

			List<Pago> objPago = new List<Pago>();

			for (int i = 0; i <= 4; i++)
			{
				objPago.Add(new Pago
				{
					IdPago = Convert.ToInt32(listaPagos[i]),
					IdOrden = Convert.ToInt32(listaOrden[i]),
					MetodoPago = listaMetodo[i],
					MontoPagado = Convert.ToInt32(listaMonto[i]),
					FechaPago = Convert.ToDateTime(listaFecha[i])
				});
			}

			_context.AddRange(objPago);
			_context.SaveChanges();
			return RedirectToAction("Index");

		}
	}
}
