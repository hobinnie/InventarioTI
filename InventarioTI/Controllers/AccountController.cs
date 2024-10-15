using InventarioTI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Necesario para manejo de sesiones
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NLog;
using System.Security.Cryptography;
using System.Text; 
public class AccountController : Controller
{
    private readonly GestionActivosDBContext _dbContext;

    public AccountController(GestionActivosDBContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IActionResult Login()
    {
        return View();
    }

    private string HashPassWord(string password)
    {
        using (var sha256 = SHA256.Create())
        {
            var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
            return Convert.ToBase64String(hashedBytes);
        }
    }

    [HttpPost]
    public IActionResult Login(string NombreUsuario, string Contraseña)
    {
        try
        {
            if (string.IsNullOrWhiteSpace(NombreUsuario) || string.IsNullOrWhiteSpace(Contraseña))
            {
                ViewBag.ErrorMessage = "El nombre de usuario y la contraseña son obligatorios";
                return View("Login");
            }

            //Cifrar la contraseña ingresada para comprobarla
            var contraseñaCifrada = HashPassWord(Contraseña);

            //Busca al usuario en la base de datos
            var usuario = _dbContext.Usuarios.FirstOrDefault(u => u.NombreUsuario
            == NombreUsuario && u.Contraseña == Contraseña);
            if (usuario != null)
            {
                //Si el usuario existe y las credenciales son correctas
                //Guardar información en inicio de sesión o usar token de autenticación

                HttpContext.Session.SetString("Usuario", usuario.NombreUsuario);

                HttpContext.Session.SetString("Rol", usuario.Rol);

                //Redirigir al panel según el rol de usuario
                return RedirectToAction(usuario.Rol == "Administrador" ? "MenúAdmin" : "Index", "Home");
            }

            //Si las credenciales son incorrectas
            ViewBag.ErrorMessage = "Usuario o contraseña incorrectos";
            return View("Login");
        }
        catch (Exception) {
            //loggear el error ??logger??
            //Logger.LogError(ex, "Error al intentar iniciar sesión");
            //mensaje
            ViewBag.ErrorMessage = "Ocurrió un error al procesar su solictud. Inténtelo más tarde ";
            return View("Login");
        }
    }

            // Método para cerrar sesión (Logout)
            public IActionResult Logout()
            {
                // Eliminar la sesión
                HttpContext.Session.Remove("Usuario");
                HttpContext.Session.Remove("Rol");

                // Opcional: Eliminar todas las sesiones si es necesario
                HttpContext.Session.Clear();

                // Redirigir al login
                return RedirectToAction("Login", "Account");
            }
        }
    

