using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Models;

namespace SGVRestaurantProject.Controllers
{
    public class BookingsController : Controller
    {
        private readonly SVGRestaurantContext _context;

        public BookingsController(SVGRestaurantContext context)
        {
            _context = context;
        }

        // GET: Bookings
        public async Task<IActionResult> Index()
        {
            var sVGRestaurantContext = _context.Bookings.Include(b => b.Restaurant).Include(b => b.Sitting).Include(b => b.User);
            return View(await sVGRestaurantContext.ToListAsync());
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


            ViewData["RestaurantId"] = new SelectList(filteredRestaurant, "RestaurantId", "RestaurantName");
            ViewData["SittingId"] = new SelectList(filteredSittings, "Value", "Text");
            ViewData["DefaultUserId"] = new SelectList(filteredUser, "Id", "UserName");
            return View();
        }

        // POST: Bookings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,SittingId,DefaultUserId,RestaurantId")] Booking booking)
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
            return RedirectToAction(nameof(Index));
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
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,SittingId,DefaultUserId,RestaurantId")] Booking booking)
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
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return (_context.Bookings?.Any(e => e.BookingId == id)).GetValueOrDefault();
        }
    }
}
