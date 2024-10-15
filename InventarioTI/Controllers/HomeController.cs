using InventarioTI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace InventarioTI.Controllers
{
     public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // Acción para iniciar sesión
        [Route("InventarioTI")]
        public IActionResult IniciarSesion()
        {
            return View();
        }

        // Nueva acción para manejar el menú de administración
        public IActionResult MenuAdmin()
        {
            // Verificar si el usuario tiene sesión y es administrador
            var usuario = HttpContext.Session.GetString("Usuario");
            var rol = HttpContext.Session.GetString("Rol");

            if (rol == "Administrador")
            {
                // Pasar los valores de usuario y rol a la vista usando ViewBag
                ViewBag.Usuario = usuario;
                ViewBag.Rol = rol;

                // Si es administrador, carga la vista del menú
                return View("MenuAdmin");
            }
            else
            {
                // Si no tiene permisos, redirigir a la página de inicio de sesión
                return RedirectToAction("IniciarSesion", "Inicio");
            }
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Dashboard()
        {
            // Logic for fetching and passing data to the view can go here
            return View();
        }
    }
}
