using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Models;
using SGVRestaurantProject.ViewModels;

namespace SGVRestaurantProject.Controllers
{
    public class BookingTImesController : Controller
    {
        private readonly SVGRestaurantContext _context;

        public BookingTImesController(SVGRestaurantContext context)
        {
            _context = context;
        }

        // GET: BookingTImes
        public IActionResult Index(int restaurantID, BookingDetailViewModel vm)
        {
            #region sitting times query
            var sittingTimes = _context.RestaurantSittings
                .Where(rs => rs.RestaurantId.Equals(restaurantID))
                .Join(_context.Sittings,
                r => r.SittingId,
                s => s.SittingId,
                (r, s) => new { restaurantSitting = r, sitting = s })
                .Select(p => new
                {
                    p.restaurantSitting.RestaurantId,
                    p.sitting.SittingStart,
                    p.sitting.SittingEnd
                })
                .OrderBy(p => p.SittingStart)
                .Select(p => $"{p.SittingStart} - {p.SittingEnd}")
                .ToList();

            vm.SittingTimes = new SelectList(sittingTimes);
            #endregion

            #region banquets query
            var data = from r in _context.Restaurants
                       join bm in _context.BanquetMenus on r.RestaurantId equals bm.RestaurantId
                       join bami in _context.BanquetAndMenuItems on bm.BanquetId equals bami.BanquetId
                       join mi in _context.MenuItems on bami.ItemId equals mi.ItemId
                       where r.RestaurantId == restaurantID
                       select new
                       {
                           restaurant = r,
                           banquetMenu = bm,
                           banquetAndMenuItems = bami,
                           menuItems = mi
                       };

            vm.Banquets = new SelectList(data.Select(d => d.banquetMenu.BanquetName).Distinct().ToList());
            #endregion
            return View(vm);
        }

        // GET: BookingTImes/Details/5
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

        // GET: BookingTImes/Create
        public IActionResult Create()
        {
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId");
            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingId");
            ViewData["UserId"] = new SelectList(_context.UserAccounts, "UserId", "UserId");
            return View();
        }

        // POST: BookingTImes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookingId,SittingId,UserId,RestaurantId")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId", booking.RestaurantId);
            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingId", booking.SittingId);
            ViewData["UserId"] = new SelectList(_context.UserAccounts, "UserId", "UserId", booking.UserId);
            return View(booking);
        }

        // GET: BookingTImes/Edit/5
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
            ViewData["UserId"] = new SelectList(_context.UserAccounts, "UserId", "UserId", booking.UserId);
            return View(booking);
        }

        // POST: BookingTImes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookingId,SittingId,UserId,RestaurantId")] Booking booking)
        {
            if (id != booking.BookingId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
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
            }
            ViewData["RestaurantId"] = new SelectList(_context.Restaurants, "RestaurantId", "RestaurantId", booking.RestaurantId);
            ViewData["SittingId"] = new SelectList(_context.Sittings, "SittingId", "SittingId", booking.SittingId);
            ViewData["UserId"] = new SelectList(_context.UserAccounts, "UserId", "UserId", booking.UserId);
            return View(booking);
        }

        // GET: BookingTImes/Delete/5
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

        // POST: BookingTImes/Delete/5
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
