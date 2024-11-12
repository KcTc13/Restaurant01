using Microsoft.AspNetCore.Mvc;
using Restauranteprueba.Datos;
using Restauranteprueba.Models;

namespace Restauranteprueba.Controllers
{
    public class ValoracionController : Controller
    {
        public readonly AplicationDbContext _context;

        public ValoracionController(AplicationDbContext aplicationDb)
        {
            _context = aplicationDb;
        }
        public IActionResult Index()
        {
            List<Valoracion> ListaValoracon = _context.Valoracion.ToList();
            return View(ListaValoracon);
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
        public IActionResult CrearMultiples(Valoracion valoracion)
        {
            String IdCliente = Request.Form["IdCliente"];
            String Comentario = Request.Form["Comentario"];
            String Puntuacion = Request.Form["Puntuacion"];
            String FechaValoracion = Request.Form["FechaValoracion"];

            var listaCliente = IdCliente.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var listaComentario = Comentario.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var listaPuntuacion = Puntuacion.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();
            var listaFecha = FechaValoracion.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.Trim())
                .ToList();

            if (listaCliente.Count == 0 | listaComentario.Count == 0 | listaPuntuacion.Count == 0 | listaFecha.Count == 0)
            {
                return CrearMultiples();
            }

            List<Valoracion> objValoracion = new List<Valoracion>();

            for (int i = 0; i <= 4; i++)
            {
                objValoracion.Add(new Valoracion
                {
                    IdCliente = Convert.ToInt32(listaCliente[i]),
                    Comentario = listaComentario[i],
                    Puntuacion = Convert.ToInt32(listaPuntuacion[i]),
                    FechaValoracion = Convert.ToDateTime(listaFecha[i]),

                });
            }

            _context.AddRange(objValoracion);
            _context.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}
