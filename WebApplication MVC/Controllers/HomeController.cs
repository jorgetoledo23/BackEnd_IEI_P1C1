using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApplication_MVC.Models;

namespace WebApplication_MVC.Controllers
{
    public class HomeController : Controller
    {
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


        //TODO: Navegacion a Adm Categorias
        //TODO: Navegacion a Adm Productos
        //TODO: Generar BD con las tablas Productos y Categorias (mismo modelo EVA 1)

    }
}