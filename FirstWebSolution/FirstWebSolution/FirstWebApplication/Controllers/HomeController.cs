using Microsoft.AspNetCore.Mvc;

namespace FirstWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Landing()
        {
            return View();
        }
    }
}
