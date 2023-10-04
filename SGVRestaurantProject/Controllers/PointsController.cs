using Microsoft.AspNetCore.Mvc;
using SGVRestaurantProject.Models;

namespace SGVRestaurantProject.Controllers
{
    public class PointsController : Controller
    {
        private readonly SVGRestaurantContext _context;

        public PointsController(SVGRestaurantContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
