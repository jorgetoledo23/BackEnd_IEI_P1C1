using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebApplication_MVC.Models;

namespace WebApplication_MVC.Controllers
{
    [Authorize(Roles = "SuperAdministrador")]
    public class ProductoController : Controller
    {
        private readonly AppDbContext _context;

        public ProductoController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> ProductoHome()
        {
            var Productos = await _context
                .Productos
                .Include(p => p.Categoria)
                .ToListAsync();

            return View(Productos);
        }

        //[Authorize(Roles = "Administrador")]
        public async Task<IActionResult> ProductoCreate()
        {
            var Categorias = await _context
                .Categorias
                .ToListAsync();
            ViewData["Perrito"] = new SelectList(Categorias, "CategoriaId", "Name");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductoCreate(Producto P)
        {
            if (ModelState.IsValid)
            {
                _context.Add(P);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ProductoHome));
            }
            else
            {
                ModelState.AddModelError("", "Ha ocurrido un erro desconocido!");
                return View(P);
            }
        }
    }
}
