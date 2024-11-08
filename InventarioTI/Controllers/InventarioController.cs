using Microsoft.AspNetCore.Mvc;
using InventarioTI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace InventarioTI.Controllers
{
    public class InventarioController : Controller
    {
        private readonly GestionActivosDBContext _dbContext;
        public InventarioController(GestionActivosDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        //panatalla principal inventario
        public IActionResult Inventario()
        {
            var query = _dbContext.Inventarios.ToList();
            return View(query);
        }

        public IActionResult Software()
        {
            var softwareList = _dbContext.Inventarios.ToList(); // Obtener los datos de software de la base de datos
            return View(softwareList);
        }

        [HttpGet]
        public IActionResult getListaDatos()
        {
            var empresa = _dbContext.CatalogoEmpresas.ToList();
            var marca = _dbContext.CatalogoMarcas.ToList();
            var zona = _dbContext.CatalogoZonas.ToList();

            var data = new
            {
                empresa,
                marca,
                zona
            };
            return Ok(data);
        }

        [HttpPost]
        public IActionResult AgregarActivo(ActivosInventario model)
        {
            var data = new Inventario
            {
                Descripcion = model.Descripcion,
                FechaC = model.FechaCompra,
                IdEmpresaKf = model.IdEmpresa,
                IdMarcaKf = model.IdMarca,
                IdZonaKf = model.IdZona
            };
            _dbContext.Inventarios.Add(data);
            _dbContext.SaveChanges();
            return RedirectToAction("Inventario");
        }

        [HttpPost]
        public IActionResult EliminarSoftware(int id)
        {
            var query = _dbContext.Inventarios.Find(id);
            _dbContext.Inventarios.Remove(query);
            _dbContext.SaveChanges();
            return RedirectToAction("Software");
        }


    }
}


