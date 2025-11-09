using Microsoft.AspNetCore.Mvc;

namespace DBapp.Contollers
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
        public IActionResult Error()
        {
            return View();
        }
    }
}
