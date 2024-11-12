using Microsoft.AspNetCore.Mvc;
using Restauranteprueba.Datos;
using Restauranteprueba.Models;

namespace Restauranteprueba.Controllers
{
    public class OrdenController : Controller
    {
        public readonly AplicationDbContext _context;

        public OrdenController(AplicationDbContext aplicationDb)
        {
            _context = aplicationDb;
        }
        public IActionResult Index()
        {
            List<Orden> ListaOrdenes = _context.Orden.ToList();
            return View(ListaOrdenes);
        }
        //Crear uno
        public IActionResult Crear()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Crear(Orden orden)
        {
            if (ModelState.IsValid)
            {
                _context.Orden.Add(orden);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Crear", orden);
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
        public IActionResult CrearMultiples(Orden orden)
        {
            String IdOrden = Request.Form["IdOrden"];
            String IdEmpleado = Request.Form["IdPago"];
            String IdCliente = Request.Form["MetodoPago"];
            String IdMesa = Request.Form["MontoPagado"];
            String FechaOrden = Request.Form["FechaOrden"];
            String EstadoOrden = Request.Form["EstadoOrden"];

            var ListaEmpleado = IdEmpleado.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var listaOrden = IdOrden.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var ListaCliente = IdCliente.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var ListaMesa = IdMesa.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var listaFecha = FechaOrden.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var ListaEstadoOrden = EstadoOrden.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            if (ListaEmpleado.Count == 0 | listaOrden.Count == 0 | ListaCliente.Count == 0 | ListaMesa.Count == 0 | listaFecha.Count == 0)
            {
                return CrearMultiples();
            }

            List<Orden> objOrden = new List<Orden>();

            for (int i = 0; i <= 4; i++)
            {
                objOrden.Add(new Orden
                {
                    IdEmpleado = Convert.ToInt32(ListaEmpleado[i]),
                    IdOrden = Convert.ToInt32(listaOrden[i]),
                    IdCliente = Convert.ToInt32(ListaCliente[i]),
                    IdMesa = Convert.ToInt32(ListaMesa[i]),
                    FechaOrden = Convert.ToDateTime(listaFecha[i]),
                    EstadoOrden = ListaEstadoOrden[i]
                });
            }

            _context.AddRange(objOrden);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
