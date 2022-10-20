using Microsoft.AspNetCore.Mvc;
using WebApplication_MVC.Models;

namespace WebApplication_MVC.Controllers
{
    public class CategoriaController : Controller
    {

        private readonly AppDbContext _context;

        public CategoriaController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult CategoriaHome()
        {
            var TodasLasCategorias = _context.Categorias.ToList();
            return View(TodasLasCategorias);
        }

        public IActionResult CategoriaCreate()
        {
            return View();
        }



        public RedirectToActionResult EliminarCategoria(int Id)
        {
            var Categoria = _context.Categorias.Find(Id);
            if(Categoria != null)
            {
                _context.Remove(Categoria);
                _context.SaveChanges();     
            }
            return RedirectToAction(nameof(CategoriaHome));
        }


    }
}
