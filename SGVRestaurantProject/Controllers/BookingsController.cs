using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Models;
using SGVRestaurantProject.Models.Users;
using SGVRestaurantProject.Models.ViewModel;

namespace SGVRestaurantProject.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly SVGRestaurantContext _context;
        private readonly UserManager<DefaultUser> _userManager;

        public BookingsController(UserManager<DefaultUser> userManager, SVGRestaurantContext context)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var sVGRestaurantContext = _context.Bookings.Include(b => b.Restaurant).Include(b => b.Sitting).Include(b => b.User);
            return View(await sVGRestaurantContext.ToListAsync());
        }

        // GET: Bookings for restaurant staff view. 
        // Shows the current reservations made for a selected restaurant
        public async Task<IActionResult> RestaurantBookings(int? restaurantId, RestaurantBookingsVM RBVM)
        {

            #region populate restaurant property in vm
            var res = await _context.Restaurants
                .Where(r => r.RestaurantId == restaurantId)
                .FirstOrDefaultAsync();
            if (res != null)
            {
                RBVM.theRestaurant = res;
            }
            #endregion

            #region Populate bookings property in vm
            var rBookings = await _context.Bookings
                .Where(b => b.RestaurantId == restaurantId)
                .Include(b => b.Sitting)
                .Include(b => b.User)
                .ToListAsync();

            RBVM.restaurantBookings = rBookings;
            #endregion

            return View(RBVM);
        }

        // GET: Bookings
        public async Task<IActionResult> UserIndex(string? userName)
        {

            var currentUser = await _userManager.FindByNameAsync(userName);

            var userId = currentUser.Id;
            var bookingDetails = _context.Bookings
                .Include(r => r.Restaurant)
                .Include(s => s.Sitting)
                .Where(u => u.DefaultUserId == userId)
                .ToList();
            return View(bookingDetails);
            

            //var sVGRestaurantContext = _context.Bookings
            //    .Include(b => b.Restaurant)
            //    .Include(b => b.Sitting)
            //    .Include(b => b.User)
            //    .Where(b => b.User.UserName == userName);
            //return View(await sVGRestaurantContext.ToListAsync());
        }
        // GET: Points
        public async Task<IActionResult> GetPoints(string? userName)
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
            #region GetPoints
            // points logic
            var completedBooking = bookingDetails.Where(c => c.Completed == "Yes");
            bookingPoints.Points = completedBooking.Count();
            bookingPoints.NumberOfBookings = bookingDetails.Count();
            #endregion

            return View(bookingPoints);

            //var sVGRestaurantContext = _context.Bookings
            //    .Include(b => b.Restaurant)
            //    .Include(b => b.Sitting)
            //    .Include(b => b.User)
            //    .Where(b => b.User.UserName == userName);
            //return View(await sVGRestaurantContext.ToListAsync());
        }
        // GET: Bookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Restaurant)
                .Include(b => b.Sitting)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Bookings/Create
        public IActionResult Create(int? restaurantId)
        {

            var filteredSittings = _context.RestaurantSittings
                .Where(rs => rs.RestaurantId == restaurantId)
                .Select(rs => new SelectListItem
                {
                    Value = rs.SittingId.ToString(),
                    Text = rs.Sitting.SittingType
                }).ToList();

            var filteredRestaurant = _context.Restaurants
                .Where(r => r.RestaurantId == restaurantId)
                .ToList();

            var currentUser = User.Identity.Name;
            var filteredUser = _context.Users
                .Where(u => u.UserName == currentUser)
                .ToList();
            var filteredBanquetMenu = _context.BanquetMenus
                .Where(b => b.RestaurantId == restaurantId).ToList();
            ViewData["RestaurantId"] = new SelectList(filteredRestaurant, "RestaurantId", "RestaurantName");
            ViewData["SittingId"] = new SelectList(filteredSittings, "Value", "Text");
            ViewData["DefaultUserId"] = new SelectList(filteredUser, "Id", "UserName");
            ViewData["BanquetList"] = new SelectList(filteredBanquetMenu, "BanquetId", "BanquetName");
            ViewBag.UserName = filteredUser.FirstOrDefault()?.UserName;
            ViewBag.RestaurantName = filteredRestaurant.FirstOrDefault()?.RestaurantName;
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,SittingId,DefaultUserId,RestaurantId,BanquetMenuID,  NumberOfGuests, BookingDate, Completed")] Booking booking)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(booking);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            //ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId", booking.RestaurantId);
            //ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingId", booking.SittingId);
            //ViewData["DefaultUserId"] = new SelectList(_context.Users, "Id", "Id", booking.DefaultUserId);
            //return View(booking);

            _context.Add(booking);
            await _context.SaveChangesAsync();
            return RedirectToAction("RestaurantPage", "Restaurants");
        }

        // GET: Bookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId", booking.RestaurantId);
            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingId", booking.SittingId);
            ViewData["DefaultUserId"] = new SelectList(_context.Users, "Id", "Id", booking.DefaultUserId);
            return View(booking);
        }

        // POST: Bookings/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,SittingId,DefaultUserId,RestaurantId,BanquetMenuID, NumberOfGuest, BookingDate, Completed")] Booking booking)
        {
            //if (id != booking.BookingId)
            //{
            //    return NotFound();
            //}

            //if (ModelState.IsValid)
            //{
            //    }
            try
            {
                _context.Update(booking);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(booking.BookingId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));

            //ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId", booking.RestaurantId);
            //ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingId", booking.SittingId);
            //ViewData["DefaultUserId"] = new SelectList(_context.Users, "Id", "Id", booking.DefaultUserId);
            //return View(booking);
        }

        // GET: Bookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bookings == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Restaurant)
                .Include(b => b.Sitting)
                .Include(b => b.User)
                .FirstOrDefaultAsync(m => m.BookingId == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Bookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bookings == null)
            {
                return Problem("Entity set 'SVGRestaurantContext.Bookings'  is null.");
            }
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction("RestaurantPage", "Restaurants");
        }

        private bool BookingExists(int id)
        {
            return (_context.Bookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
