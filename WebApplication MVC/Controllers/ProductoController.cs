using Microsoft.AspNetCore.Mvc;

namespace WebApplication_MVC.Controllers
{
    public class ProductoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
