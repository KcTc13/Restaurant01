using Microsoft.AspNetCore.Mvc;
using Restauranteprueba.Datos;
using Restauranteprueba.Models;

namespace Restauranteprueba.Controllers
{
    public class ReservaController : Controller
    {
        public readonly AplicationDbContext _context;

        public ReservaController(AplicationDbContext aplicationDb)
        {
            _context = aplicationDb;
        }
        public IActionResult Index()
        {
            List<Reserva> ListaReservas = _context.Reserva.ToList();
            return View(ListaReservas);
        }
        //Crear uno
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Reserva reserva)
        {
            if (ModelState.IsValid)
            {
                _context.Reserva.Add(reserva);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Crear", reserva);
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
        public IActionResult CrearMultiples(Reserva reserva)
        {
            String IdReserva = Request.Form["IdReserva"];
            String IdCliente = Request.Form["IdCliente"];
            String IdMesa = Request.Form["IdMesa"];
            String EstadoReserva = Request.Form["EstadoReserva"];
            String FechaHoraReserva = Request.Form["FechaHoraReserva"];

            var listaReservas = IdReserva.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var listaClientes = IdCliente.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var listaMesa = IdMesa.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var ListaEstado = EstadoReserva.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var listaFecha = FechaHoraReserva.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            if (listaReservas.Count == 0 | listaClientes.Count == 0 | listaMesa.Count == 0 | ListaEstado.Count == 0 | listaFecha.Count == 0)
            {
                return CrearMultiples();
            }

            List<Reserva> objReserva = new List<Reserva>();

            for (int i = 0; i <= 4; i++)
            {
                objReserva.Add(new Reserva
                {
                    IdReserva = Convert.ToInt32(listaReservas[i]),
                    IdCliente = Convert.ToInt32(listaClientes[i]),
                    IdMesa = Convert.ToInt32(listaMesa[i]),
                    EstadoReserva = ListaEstado[i],
                    FechaHoraReserva = Convert.ToDateTime(listaFecha[i])
                });
            }

            _context.AddRange(objReserva);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
