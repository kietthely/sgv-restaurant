using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Models;
using SGVRestaurantProject.Models.ViewModel;
using static SGVRestaurantProject.Models.ViewModel.BanquetMenuViewModel;

namespace SGVRestaurantProject.Controllers
{
    public class BanquetMenusController : Controller
    {
        private readonly SVGRestaurantContext _context;

        public BanquetMenusController(SVGRestaurantContext context)
        {
            _context = context;
        }

        // GET: BanquetMenus
        public async Task<IActionResult> Index()
        {

            var indexQuery = _context.BanquetMenus
                .Include(r => r.Restaurant);

              return _context.BanquetMenus != null ? 
                          View(indexQuery) :
                          Problem("Entity set 'SVGRestaurantContext.BanquetMenus'  is null.");
        }

        //// GET: BanquetMenus/EditBanquetMenuItems/1
        //// This directs to a page where menu items are listed available to be deleted via a button.
        //public async Task<IActionResult> EditBanquetMenuItems(int? id)
        //{

        //    var banquetMenu = _context.BanquetMenus
        //    .Include(b => b.Restaurant)
        //    .Include(b => b.BanquetAndMenuItems)
        //    .ThenInclude(bam => bam.Item)
        //    .FirstOrDefault(b => b.BanquetId == id);


        //    if (banquetMenu == null)
        //    {
        //        return NotFound();
        //    }

        //    var viewModel = new BanquetMenuViewModel
        //    {
        //        BanquetId = banquetMenu.BanquetId,
        //        BanquetName = banquetMenu.BanquetName,
        //        RestaurantId = banquetMenu.RestaurantId,
        //        BanquetCost = banquetMenu.BanquetCost,
        //        BanquetAvailability = banquetMenu.BanquetAvailability,
        //        RestaurantName = banquetMenu.Restaurant.RestaurantName,
        //        MenuItems = banquetMenu.BanquetAndMenuItems
        //       .Select(bam => bam.Item)
        //       .ToList()
        //    };

        //    // Return BanquetMenuViewModel that provides information on what menu items are in a banquet.
        //    return View(viewModel);
        //}

        // GET: BanquetMenus/DeleteBanquetMenuItem/
        //public async Task<IActionResult> DeleteBanquetMenuItem(int? banquetId, int? itemId)
        //{
        //    // query to include the banquet with matching banquetId.
        //    var banquetMenu =  _context.BanquetMenus
        //        .Include(b => b.BanquetAndMenuItems)
        //        .FirstOrDefault(b => b.BanquetId == banquetId);

        //    if (banquetMenu == null)
        //    { 
        //        return NotFound(); 
        //    }

        //    // query to include the menu items that match itemId
        //    var banquetAndMenuItem = banquetMenu.BanquetAndMenuItems
        //        .FirstOrDefault(bam => bam.ItemId == itemId);

        //    if (banquetAndMenuItem == null)
        //    {
        //        return NotFound();
        //    }

        //    banquetMenu.BanquetAndMenuItems.Remove(banquetAndMenuItem);

        //    _context.SaveChanges();

        //    return RedirectToAction("EditBanquetMenuItems", new { banquetId });
        //}

        // GET: BanquetMenus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BanquetMenus == null)
            {
                return NotFound();
            }

            //var banquetMenuDetails = (from bm in _context.BanquetMenus
            //                          join r in _context.Restaurants
            //                          on bm.RestaurantId equals r.RestaurantId
            //                          where bm.BanquetId == id
            //                          select new
            //                          {
            //                              r.RestaurantName,
            //                              bm.BanquetId,
            //                              bm.BanquetName,
            //                              bm.BanquetCost,
            //                              bm.BanquetAvailability,
            //                          });

            var banquetMenu = await _context.BanquetMenus
                .FirstOrDefaultAsync(m => m.BanquetId == id);

            if (banquetMenu == null)
            {
                return NotFound();
            }

           
            //var restaurantName = _context.Restaurants
            //    .Join(_context.BanquetMenus,
            //    i => i.RestaurantId,
            //    bm => bm.RestaurantId,
            //    (i, bm) => new { restaurant = i, banquetMenu = bm })
            //    .Select(p => new
            //    { p.restaurant.RestaurantName });

            //var restaurant = (from r in _context.Restaurants
            //                  join bm in _context.BanquetMenus
            //                  on r.RestaurantId equals bm.RestaurantId
            //                  select new
            //                  {
            //                      r.RestaurantName,
            //                  });

            //ViewBag.Name = restaurantName.; Trying to get restaurant name to show up.

            return View(banquetMenu);
        }

        // GET: BanquetMenus/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: BanquetMenus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BanquetId,BanquetName,RestaurantId,BanquetCost,BanquetAvailability")] BanquetMenu banquetMenu)
        {
            _context.Add(banquetMenu);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            
        }

        // GET: BanquetMenus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BanquetMenus == null)
            {
                return NotFound();
            }

            var banquetMenu = await _context.BanquetMenus.FindAsync(id);
            if (banquetMenu == null)
            {
                return NotFound();
            }
            return View(banquetMenu);
        }

        // POST: BanquetMenus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BanquetId,BanquetName,RestaurantId,BanquetCost,BanquetAvailability")] BanquetMenu banquetMenu)
        {
            if (id != banquetMenu.BanquetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banquetMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanquetMenuExists(banquetMenu.BanquetId))
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
            return View(banquetMenu);
        }

        // GET: BanquetMenus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BanquetMenus == null)
            {
                return NotFound();
            }

            var banquetMenu = await _context.BanquetMenus
                .FirstOrDefaultAsync(m => m.BanquetId == id);
            if (banquetMenu == null)
            {
                return NotFound();
            }

            return View(banquetMenu);
        }

        // POST: BanquetMenus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BanquetMenus == null)
            {
                return Problem("Entity set 'SVGRestaurantContext.BanquetMenus'  is null.");
            }
            var banquetMenu = await _context.BanquetMenus.FindAsync(id);
            if (banquetMenu != null)
            {
                _context.BanquetMenus.Remove(banquetMenu);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BanquetMenuExists(int id)
        {
          return (_context.BanquetMenus?.Any(e => e.BanquetId == id)).GetValueOrDefault();
        }
    }
}
