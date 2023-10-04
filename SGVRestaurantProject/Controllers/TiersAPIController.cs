using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Models;
using SGVRestaurantProject.Models.Users;
using SGVRestaurantProject.Models.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SGVRestaurantProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TiersAPIController : ControllerBase
    {
        private readonly SVGRestaurantContext _context;
        private readonly UserManager<DefaultUser> _userManager;

        public TiersAPIController(UserManager<DefaultUser> userManager, SVGRestaurantContext context)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET: api/<TiersAPIController>
        [HttpGet]
        public async Task<string> GetTier(string userName)
        {
            var currentUser = await _userManager.FindByNameAsync(userName);
            BookingPoints bookingPoints = new BookingPoints();
            var userId = currentUser.Id;
            #region BookingDetailsQuery

            var bookingDetails = _context.Bookings
                .Include(r => r.Restaurant)
                .Include(s => s.Sitting)
                .Where(u => u.DefaultUserId == userId)
                .ToList();
            bookingPoints.BookingDetails = bookingDetails;
            #endregion

            // points logic
            var completedBooking = bookingDetails.Where(c => c.Completed == "Yes");
            bookingPoints.Points = completedBooking.Count();
            bookingPoints.NumberOfBookings = bookingDetails.Count();

            if (bookingPoints.Points >= 1 && bookingPoints.Points <= 2)
            {
                return "Silver";
            }
            else if (bookingPoints.Points > 2)
            {
                return "Gold";
            }
            return "Bronze";
        }
    }
}
