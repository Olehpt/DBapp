using Microsoft.AspNetCore.Mvc;
using DBapp.Data;
using DBapp.Models;
namespace DBapp.Contollers
{
    public class QuerriesController : Controller
    {
        private readonly DB1Context _context;
        public QuerriesController(DB1Context context)
        {
            _context = context;
        }
        public IActionResult Index(double? targetprice)
        {
            if (targetprice != null)
            {
                ViewBag.Products = _context.Products
                    .Where(p => p.UnitPrice < targetprice)
                    .ToList();
            }
            return View();
        }
    }
}
