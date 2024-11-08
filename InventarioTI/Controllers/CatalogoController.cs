using Microsoft.AspNetCore.Mvc;
using InventarioTI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace InventarioTI.Controllers
{
    public class CatalogoController : Controller
    {
        private readonly GestionActivosDBContext _dbContext;
        public CatalogoController(GestionActivosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Métodos para Departamentos
        public IActionResult Indexado()
        {
            var query = _dbContext.CatalogoDptos.ToList();
            return View(query);
        }

        [HttpPost]
        public IActionResult Crear(CatalogoDpto model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CatalogoDptos.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Indexado");
            }
            return RedirectToAction("Indexado"); // Si hay algún error, sigue mostrando la misma vista
        }

        public IActionResult Editar(int id)
        {
            var departamento = _dbContext.CatalogoDptos.Find(id); // Buscar el departamento por su ID
            if (departamento == null)
            {
                return NotFound(); // Retornar una vista de error si no se encuentra el departamento
            }
            return View(departamento); // Pasar el modelo a la vista para que sea editado
        }

        // Recibir los cambios y actualizarlos en la base de datos
        [HttpPost]
        public IActionResult Editar(CatalogoDpto model)
        {
            if (ModelState.IsValid)
            {
                var departamento = _dbContext.CatalogoDptos.Find(model.IdDpto); // Encontrar el departamento por ID
                if (departamento == null)
                {
                    return NotFound();
                }

                // Actualizar el nombre del departamento
                departamento.Departamento = model.Departamento;

                _dbContext.CatalogoDptos.Update(departamento); // Marcar el objeto como modificado
                _dbContext.SaveChanges(); // Guardar los cambios en la base de datos

                return RedirectToAction("Indexado"); // Redirigir a la vista principal después de modificar
            }
            return View(model); // Si hay errores de validación, seguir mostrando el formulario
        }

        public IActionResult Eliminar(int id)
        {
            var query = _dbContext.CatalogoDptos.Find(id);
            _dbContext.CatalogoDptos.Remove(query);
            _dbContext.SaveChanges();
            return RedirectToAction("Indexado");
        }

        // Métodos para Empresa
        public IActionResult Empresa()
        {
            var query = _dbContext.CatalogoEmpresas.ToList();
            return View(query);
        }

        [HttpPost]
        public IActionResult CrearEmpresa(CatalogoEmpresa model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CatalogoEmpresas.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Empresa");
            }
            return RedirectToAction("Empresa"); // Si hay algún error, sigue mostrando la misma vista
        }

        public IActionResult EditarEmpresa(int id)
        {
            var empresa = _dbContext.CatalogoEmpresas.Find(id); // 
            if (empresa == null)
            {
                return NotFound(); // Retornar una vista de error si no se encuentra el departamento
            }
            return View(empresa); // Pasar el modelo a la vista para que sea editado
        }

        // Recibir los cambios y actualizarlos en la base de datos
        [HttpPost]
        public IActionResult EditarEmpresa(CatalogoEmpresa model)
        {
            if (ModelState.IsValid)
            {
                var empresa = _dbContext.CatalogoEmpresas.Find(model.IdEmpresa); // 
                if (empresa == null)
                {
                    return NotFound();
                }

                // Actualizar el nombre del departamento
                empresa.Clave = model.Clave;


                _dbContext.CatalogoEmpresas.Update(empresa); // Marcar el objeto como modificado
                _dbContext.SaveChanges(); // Guardar los cambios en la base de datos

                return RedirectToAction("Empresa"); // Redirigir a la vista principal después de modificar
            }
            return View(model); // Si hay errores de validación, seguir mostrando el formulario
        }

        public IActionResult EliminarEmpresa(int id)
        {
            var query = _dbContext.CatalogoEmpresas.Find(id);
            _dbContext.CatalogoEmpresas.Remove(query);
            _dbContext.SaveChanges();
            return RedirectToAction("Empresa");
        }



        // Métodos para Marcas
        public IActionResult Marca()
        {
            var query = _dbContext.CatalogoMarcas.ToList();
            return View(query);
        }

        [HttpPost]
        public IActionResult CrearMarca(CatalogoMarca model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CatalogoMarcas.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Marca");
            }
            return RedirectToAction("Marca"); // Si hay algún error, sigue mostrando la misma vista
        }

        public IActionResult EditarMarca(int id)
        {
            var marca = _dbContext.CatalogoMarcas.Find(id); // Buscar el departamento por su ID
            if (marca == null)
            {
                return NotFound(); // Retornar una vista de error si no se encuentra el departamento
            }
            return View(marca); // Pasar el modelo a la vista para que sea editado
        }

        // Recibir los cambios y actualizarlos en la base de datos
        [HttpPost]
        public IActionResult EditarMarca(CatalogoMarca model)
        {
            if (ModelState.IsValid)
            {
                var marca = _dbContext.CatalogoMarcas.Find(model.IdMarca); // Encontrar el departamento por ID
                if (marca == null)
                {
                    return NotFound();
                }

                // Actualizar el nombre del departamento
                marca.Marca = model.Marca;

                _dbContext.CatalogoMarcas.Update(marca); // Marcar el objeto como modificado
                _dbContext.SaveChanges(); // Guardar los cambios en la base de datos

                return RedirectToAction("Marca"); // Redirigir a la vista principal después de modificar
            }
            return View(model); // Si hay errores de validación, seguir mostrando el formulario
        }
        public IActionResult EliminarMarca(int id)
        {
            var query = _dbContext.CatalogoMarcas.Find(id);
            _dbContext.CatalogoMarcas.Remove(query);
            _dbContext.SaveChanges();
            return RedirectToAction("Marca");
        }

        // Métodos para Zonas
        public IActionResult Zona()
        {
            var query = _dbContext.CatalogoZonas.ToList();
            return View(query);
        }

        [HttpPost]

        public IActionResult CrearZona(CatalogoZona model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CatalogoZonas.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Zona");
            }
            return RedirectToAction("Zona");
        }
        public IActionResult ModificarZona(int id)
        {
            var zona = _dbContext.CatalogoZonas.Find(id); // Buscar el departamento por su ID
            if (zona == null)
            {
                return NotFound(); // Retornar una vista de error si no se encuentra el departamento
            }
            return View(zona);
        }

        [HttpPost]
        public IActionResult ModificarZona(CatalogoZona model)
        {
            if (ModelState.IsValid)
            {
                var zona = _dbContext.CatalogoZonas.Find(model.IdZona); // Encontrar el departamento por ID
                if (zona == null)
                {
                    return NotFound();
                }

                // Actualizar el nombre del departamento
                zona.Zona = model.Zona;

                _dbContext.CatalogoZonas.Update(zona); // Marcar el objeto como modificado
                _dbContext.SaveChanges(); // Guardar los cambios en la base de datos

                return RedirectToAction("Zona"); // Redirigir a la vista principal después de modificar
            }
            return View(model); // Si hay errores de validación, seguir mostrando el formulario
        }
        public IActionResult EliminarZona(int id)
        {
            var query = _dbContext.CatalogoZonas.Find(id);
            _dbContext.CatalogoZonas.Remove(query);
            _dbContext.SaveChanges();
            return RedirectToAction("Zona");
        }

        // Métodos para Puestos
        public IActionResult Puestos()
        {
            var query = _dbContext.CatalogoPuestos.ToList();
            return View(query);
        }

        [HttpPost]
        public IActionResult CrearPuesto(CatalogoPuesto model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.CatalogoPuestos.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Puestos");
            }
            return RedirectToAction("Puestos");
        }
        public IActionResult EditarPuesto(int id)
        {
            var puesto = _dbContext.CatalogoPuestos.Find(id); // Buscar el departamento por su ID
            if (puesto == null)
            {
                return NotFound(); // Retornar una vista de error si no se encuentra el departamento
            }
            return View(puesto); // Pasar el modelo a la vista para que sea editado
        }

        // Recibir los cambios y actualizarlos en la base de datos
        [HttpPost]
        public IActionResult EditarPuesto(CatalogoPuesto model)
        {
            if (ModelState.IsValid)
            {
                var puesto = _dbContext.CatalogoPuestos.Find(model.IdEmpleado); // Encontrar el departamento por ID
                if (puesto == null)
                {
                    return NotFound();
                }

                // Actualizar el nombre del departamento
                puesto.Puesto = model.Puesto;

                _dbContext.CatalogoPuestos.Update(puesto); // Marcar el objeto como modificado
                _dbContext.SaveChanges(); // Guardar los cambios en la base de datos

                return RedirectToAction("Puestos"); // Redirigir a la vista principal después de modificar
            }
            return View(model); // Si hay errores de validación, seguir mostrando el formulario
        }

        public IActionResult EliminarPuesto(int id)
        {
            var query = _dbContext.CatalogoPuestos.Find(id);
            _dbContext.CatalogoPuestos.Remove(query);
            _dbContext.SaveChanges();
            return RedirectToAction("Puestos");
        }

        // Métodos para Administración de Usuarios
        public IActionResult Configuración()
        {
            var query = _dbContext.Usuarios.ToList();
            return View(query);
        }

        [HttpPost]
        public IActionResult Crearusuario(Usuario model)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Usuarios.Add(model);
                _dbContext.SaveChanges();
                return RedirectToAction("Configuración");
            }
            return RedirectToAction("Configuración"); // Si hay algún error, sigue mostrando la misma vista
        }

        public IActionResult Editarusuario(int id)
        {
            var usuario = _dbContext.Usuarios.Find(id); // Buscar el departamento por su ID
            if (usuario == null)
            {
                return NotFound(); // Retornar una vista de error si no se encuentra el departamento
            }
            return View(usuario); // Pasar el modelo a la vista para que sea editado
        }

        // Recibir los cambios y actualizarlos en la base de datos
        [HttpPost]
        public IActionResult EditarUsuario(Usuario model)
        {
            if (ModelState.IsValid)
            {
                var usuario = _dbContext.Usuarios.Find(model.IdUsuario); // Encontrar el departamento por ID
                if (usuario == null)
                {
                    return NotFound();
                }

                // Actualizar el nombre del departamento
                usuario.NombreUsuario = model.NombreUsuario;

                _dbContext.Usuarios.Update(usuario); // Marcar el objeto como modificado
                _dbContext.SaveChanges(); // Guardar los cambios en la base de datos

                return RedirectToAction("Configuración"); // Redirigir a la vista principal después de modificar
            }
            return View(model); // Si hay errores de validación, seguir mostrando el formulario
        }

        public IActionResult EliminarUsuario(int id)
        {
            var query = _dbContext.Usuarios.Find(id);
            _dbContext.Usuarios.Remove(query);
            _dbContext.SaveChanges();
            return RedirectToAction("Configuración");
        }

    }
}
