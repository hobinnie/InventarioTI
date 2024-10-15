using InventarioTI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace InventarioTI.Controllers
{
    public class InicioController : Controller
    {
        // Simulación de usuarios con diferentes roles
        // validar con base de datos
        private Dictionary<string, (string password, string role)> usuarios = new Dictionary<string, (string password, string role)>
        {
            { "Miranda", ("3456", "Administrador") }, // Usuario administrador
            { "Usuario1", ("1234", "Usuario") },      // Usuario con permisos limitados
        };

        [HttpPost]
        public IActionResult IniciarSesion(string Nombre_usuario, string contraseña)
        {
            // Validación de credenciales
            if (usuarios.ContainsKey(Nombre_usuario) && usuarios[Nombre_usuario].password == contraseña)
            {
                // Obtener el rol del usuario
                var rol = usuarios[Nombre_usuario].role;

                // Establecer la sesión del usuario
                HttpContext.Session.SetString("Usuario", Nombre_usuario);
                HttpContext.Session.SetString("Rol", rol);

                // Redirigir según el rol del usuario
                if (rol == "Administrador")
                {
                    return RedirectToAction("MenuAdmin", "Home");
                }
                else
                {
                    return RedirectToAction("MenuUsuario", "Home");
                }
            }
            else
            {
                // Si las credenciales son incorrectas, mostrar mensaje de error
                ViewData["Mensaje"] = "Usuario o contraseña incorrectos.";
                return View();
            }
        }
    }
}