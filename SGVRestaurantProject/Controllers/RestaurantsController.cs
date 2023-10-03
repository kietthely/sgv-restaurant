using System;
using System.Collections.Generic;
using System.Linq;
//using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
//using AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Models;

namespace SGVRestaurantProject.Controllers
{
    public class RestaurantsController : Controller
    {
        private readonly SVGRestaurantContext _context;

        public RestaurantsController(SVGRestaurantContext context)
        {
            _context = context;
        }

        // GET: Restaurants
        [Authorize(Roles ="Admin, Staff")]
        public async Task<IActionResult> Index()
        {
              return _context.Restaurants != null ? 
                          View(await _context.Restaurants.ToListAsync()) :
                          Problem("Entity set 'SVGRestaurantContext.Restaurants'  is null.");
        }

        [AllowAnonymous]
        public async Task<IActionResult> RestaurantPage()
        {
            var query = _context.Restaurants;

            return View(await query.ToListAsync());
        }

        // GET: Restaurants/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var query = await _context.Restaurants
                .Include(r => r.BanquetMenus)
                .ThenInclude(bm => bm.BanquetAndMenuItems)
                .ThenInclude(bami => bami.Item)
                .Where(r => r.RestaurantId == id)
                .Select(r => new CompleteRestaurantDetails
                {
                    theRestaurant = r,
                    banquets = r.RestaurantBanquetMenus.ToList(),
                    banquetMenus = r.BanquetMenus.ToList(),
                    bami = r.BanquetMenus
                        .SelectMany(bm => bm.BanquetAndMenuItems)
                        .ToList(),
                    menuItems = r.BanquetMenus
                        .SelectMany(bm => bm.BanquetAndMenuItems)
                        .Select(bami => bami.Item)
                        .ToList()
                })
                .FirstOrDefaultAsync();


            if (query == null)
            {
                return NotFound();
            }

            return View(query);

        }

        // GET: Restaurants/Create
        [Authorize(Roles ="Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Restaurants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RestaurantId,RestaurantAddress,RestaurantName")] Restaurant restaurant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(restaurant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(restaurant);
        }

        // GET: Restaurants/Edit/5
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            return View(restaurant);
        }

        // POST: Restaurants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles ="Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RestaurantId,RestaurantAddress,RestaurantName")] Restaurant restaurant)
        {
            if (id != restaurant.RestaurantId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(restaurant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RestaurantExists(restaurant.RestaurantId))
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
            return View(restaurant);
        }

        // GET: Restaurants/Delete/5
        [Authorize(Roles ="Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Restaurants == null)
            {
                return NotFound();
            }

            var restaurant = await _context.Restaurants
                .FirstOrDefaultAsync(m => m.RestaurantId == id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return View(restaurant);
        }

        // POST: Restaurants/Delete/5
        [Authorize(Roles ="Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Restaurants == null)
            {
                return Problem("Entity set 'SVGRestaurantContext.Restaurants'  is null.");
            }
            var restaurant = await _context.Restaurants.FindAsync(id);
            if (restaurant != null)
            {
                _context.Restaurants.Remove(restaurant);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RestaurantExists(int id)
        {
          return (_context.Restaurants?.Any(e => e.RestaurantId == id)).GetValueOrDefault();
        }
    }
}
