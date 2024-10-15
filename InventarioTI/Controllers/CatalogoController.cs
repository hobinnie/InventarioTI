using Microsoft.AspNetCore.Mvc;
using InventarioTI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace InventarioTI.Controllers
{
    public class CatalogoController : Controller
    {
        // Listas estáticas para almacenar datos
        private static List<Departamento> departamentos = new List<Departamento>();
        private static List<string> empresas = new List<string>();
        private static List<string> marcas = new List<string>();
        private static List<string> zonas = new List<string>();
        private static List<string> puestos = new List<string>();
        private static List<string> usuarios = new List<string>();

        // Métodos para Departamentos
        public IActionResult Indexado()
        {
            return View(departamentos);
        }

        [HttpPost]
        public IActionResult Crear(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                departamento.Id = departamentos.Count + 1; // Asignar ID
                departamentos.Add(departamento);
                return RedirectToAction("Indexado");
            }
            return RedirectToAction("Indexado"); // Si hay algún error, sigue mostrando la misma vista
        }

        public IActionResult Editar(int id)
        {
            var departamento = departamentos.FirstOrDefault(d => d.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        [HttpPost]
        public IActionResult Editar(Departamento departamento)
        {
            if (ModelState.IsValid)
            {
                var existingDepartamento = departamentos.FirstOrDefault(d => d.Id == departamento.Id);
                if (existingDepartamento != null)
                {
                    existingDepartamento.nombreDepartamento = departamento.nombreDepartamento;
                }
                return RedirectToAction("Indexado");
            }
            return View(departamento);
        }

        public IActionResult Eliminar(int id)
        {
            var departamento = departamentos.FirstOrDefault(d => d.Id == id);
            if (departamento != null)
            {
                departamentos.Remove(departamento);
            }
            return RedirectToAction("Indexado");
        }

        // Métodos para Empresas
        public IActionResult Empresa()
        {
            return View(empresas); // Pasa la lista de empresas a la vista
        }

        [HttpPost]
        public IActionResult CrearEmpresa(string nuevaEmpresa)
        {
            if (!string.IsNullOrWhiteSpace(nuevaEmpresa))
            {
                empresas.Add(nuevaEmpresa); // Añade la nueva empresa a la lista
            }
            return RedirectToAction("Empresa");
        }

        public IActionResult EliminarEmpresa(string empresa)
        {
            empresas.Remove(empresa); // Elimina la empresa de la lista
            return RedirectToAction("Empresa");
        }

        [HttpPost]
        public IActionResult ModificarEmpresa(string antiguaEmpresa, string nuevaEmpresa)
        {
            int index = empresas.IndexOf(antiguaEmpresa);
            if (index != -1 && !string.IsNullOrWhiteSpace(nuevaEmpresa))
            {
                empresas[index] = nuevaEmpresa; // Modifica la empresa existente
            }
            return RedirectToAction("Empresa");
        }

        // Métodos para Marcas
        public IActionResult Marca()
        {
            return View(marcas); // Pasa la lista de marcas a la vista
        }

        [HttpPost]
        public IActionResult CrearMarca(string nuevaMarca)
        {
            if (!string.IsNullOrWhiteSpace(nuevaMarca))
            {
                marcas.Add(nuevaMarca); // Añade la nueva marca a la lista
            }
            return RedirectToAction("Marca");
        }

        public IActionResult EliminarMarca(string marca)
        {
            marcas.Remove(marca); // Elimina la marca de la lista
            return RedirectToAction("Marca");
        }

        [HttpPost]
        public IActionResult ModificarMarca(string antiguaMarca, string nuevaMarca)
        {
            int index = marcas.IndexOf(antiguaMarca);
            if (index != -1 && !string.IsNullOrWhiteSpace(nuevaMarca))
            {
                marcas[index] = nuevaMarca; // Modifica la marca existente
            }
            return RedirectToAction("Marca");
        }

        // Métodos para Zonas
        public IActionResult Zona()
        {
            return View(zonas); // Pasa la lista de zonas a la vista
        }

        [HttpPost]
        public IActionResult CrearZona(string nuevaZona)
        {
            if (!string.IsNullOrWhiteSpace(nuevaZona))
            {
                zonas.Add(nuevaZona); // Añade la nueva zona a la lista
            }
            return RedirectToAction("Zona");
        }

        public IActionResult EliminarZona(string zona)
        {
            zonas.Remove(zona); // Elimina la zona de la lista
            return RedirectToAction("Zona");
        }

        [HttpPost]
        public IActionResult ModificarZona(string antiguaZona, string nuevaZona)
        {
            int index = zonas.IndexOf(antiguaZona);
            if (index != -1 && !string.IsNullOrWhiteSpace(nuevaZona))
            {
                zonas[index] = nuevaZona; // Modifica la zona existente
            }
            return RedirectToAction("Zona");
        }

        // Métodos para Puestos
        public IActionResult Puestos()
        {
            return View(puestos); // Pasa la lista de puestos a la vista
        }

        [HttpPost]
        public IActionResult CrearPuesto(string nuevoPuesto)
        {
            if (!string.IsNullOrWhiteSpace(nuevoPuesto))
            {
                puestos.Add(nuevoPuesto); // Añade la nueva zona a la lista
            }
            return RedirectToAction("Puestos");
        }

        public IActionResult EliminarPuesto(string puesto)
        {
            puestos.Remove(puesto); // Elimina la zona de la lista
            return RedirectToAction("Puestos");
        }

        //[HttpPost]
        public IActionResult ModificarPuesto(string antiguoPuesto, string nuevoPuesto)
        {
            int index = puestos.IndexOf(antiguoPuesto);
            if (index != -1 && !string.IsNullOrWhiteSpace(nuevoPuesto))
            {
                puestos[index] = nuevoPuesto; // Modifica la zona existente
            }
            return RedirectToAction("Puestos");
        }

        // Métodos para Administración de Usuarios
        public IActionResult Configuración()
        {
            return View(usuarios); // Pasa la lista de empresas a la vista
        }

        [HttpPost]
        public IActionResult CrearUsuario(string nuevoUsuario)
        {
            if (!string.IsNullOrWhiteSpace(nuevoUsuario))
            {
                usuarios.Add(nuevoUsuario); // Añade el nuevo usuario a la lista
            }
            return RedirectToAction("Configuración");
        }

        public IActionResult EliminarUsuario(string usuario)
        {
            empresas.Remove(usuario); // Elimina el usuario de la lista
            return RedirectToAction("Configuración");
        }

        [HttpPost]
        public IActionResult ModificarUsuario(string antiguoUsuario, string nuevoUsuario)
        {
            int index = empresas.IndexOf(antiguoUsuario);
            if (index != -1 && !string.IsNullOrWhiteSpace(nuevoUsuario))
            {
                empresas[index] = nuevoUsuario; // Modifica el usuario existente
            }
            return RedirectToAction("Configuración");
        }
    }
}


