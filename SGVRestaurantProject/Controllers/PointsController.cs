using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Models;
using SGVRestaurantProject.Models.Users;

namespace SGVRestaurantProject.Controllers
{
    public class PointsController : Controller
    {
        private readonly SVGRestaurantContext _context;
        private readonly UserManager<DefaultUser> _userManager;

        public PointsController(UserManager<DefaultUser> userManager, SVGRestaurantContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Points()
        {
            // select all bookings that are completed = true.
            // need to group these by user ID
            var userPoints = await _context.Bookings
                .Where(b => b.Completed == "Yes")
                .GroupBy(b => b.DefaultUserId)
                .Select(data => new UserPointsViewModel
                {
                    userId = data.Key,
                    NumberOfPoints = data.Count(),
                    FirstName = data.First().User.FirstName,
                    LastName = data.First().User.LastName,
                })
                .ToListAsync();
            
            return View(userPoints);
        }
    }
}
