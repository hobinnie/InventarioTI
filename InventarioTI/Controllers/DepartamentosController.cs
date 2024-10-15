using InventarioTI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;


namespace InventarioTI.Controllers
{
    public class DepartamentosController : Controller
    {
        private readonly GestionActivosDBContext _context;

        public DepartamentosController(GestionActivosDBContext context)
        {
            _context = context;
        }

        //Acción para listar todos los departamentos
        public IActionResult Index()
        {
            var departamentos = _context.CatalogoDptos.ToList();
            return View(departamentos);
        }
        //acción para mostrar el formulario de creación de un nuevo departamento
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Crear(CatalogoDpto departamento)
        {
            if (ModelState.IsValid)
            {
                _context.CatalogoDptos.Add(departamento);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }
        //Acción que genera editar departamento
        public IActionResult Editar(int id)
        {
            var departamento = _context.CatalogoDptos.FirstOrDefault(d => d.IdDpto == id);
            if (departamento == null)
            {
                return NotFound();
            }
            return View(departamento);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Editar(CatalogoDpto departamento)
        {
            if (ModelState.IsValid)
            {
                _context.CatalogoDptos.Update(departamento);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(departamento);
        }
        //Acción para eliminar un departamento
        public IActionResult Eliminar(int id)
        {
            var departamento = _context.CatalogoDptos.FirstOrDefault(d => d.IdDpto == id);
                if(departamento == null)
            {
                return NotFound();
            }
                return View(departamento);
        }

        [HttpPost, ActionName("Eliminar")]
        [ValidateAntiForgeryToken]

        public IActionResult EliminarConfirmado(int id)
        {
            var departamento = _context.CatalogoDptos.FirstOrDefault(d =>d.IdDpto == id);
            
            _context.CatalogoDptos.Remove(departamento);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
