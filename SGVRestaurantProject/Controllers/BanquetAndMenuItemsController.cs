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
    public class BanquetAndMenuItemsController : Controller
    {
        private readonly SVGRestaurantContext _context;

        public BanquetAndMenuItemsController(SVGRestaurantContext context)
        {
            _context = context;
        }

        // GET: BanquetAndMenuItems
        public async Task<IActionResult> Index()
        {
            var sVGRestaurantContext = _context.BanquetAndMenuItems.Include(b => b.Banquet).Include(b => b.Item);
            return View(await sVGRestaurantContext.ToListAsync());
        }

        // GET: BanquetAndMenuItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BanquetAndMenuItems == null)
            {
                return NotFound();
            }

            var banquetAndMenuItem = await _context.BanquetAndMenuItems
                .Include(b => b.Banquet)
                .Include(b => b.Item)
                .FirstOrDefaultAsync(m => m.BanquetAndMenuItemsId == id);
            if (banquetAndMenuItem == null)
            {
                return NotFound();
            }

            return View(banquetAndMenuItem);
        }

        // GET: BanquetAndMenuItems/Create
        public IActionResult Create(int? menuItemId)
        {
            var itemName = _context.MenuItems
        .Where(m => m.ItemId == menuItemId)
        .Select(i => i.ItemName)
        .FirstOrDefault();
            ViewData["ItemId"] = new SelectList(_context.MenuItems, "ItemId", "ItemId");
            ViewData["menuItemId"]= menuItemId;
            ViewData["menuItemName"] = itemName;
            ViewData["BanquetId"] = new SelectList(_context.BanquetMenus, "BanquetId", "BanquetId");
            //ViewData["ItemId"] = new SelectList(_context.MenuItems, "ItemId", "ItemId");
            return View();
        }

        // POST: BanquetAndMenuItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BanquetAndMenuItemsId,ItemId,BanquetId")] BanquetAndMenuItem banquetAndMenuItem)
    {
            _context.Add(banquetAndMenuItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: BanquetAndMenuItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BanquetAndMenuItems == null)
            {
                return NotFound();
            }

            var banquetAndMenuItem = await _context.BanquetAndMenuItems.FindAsync(id);
            if (banquetAndMenuItem == null)
            {
                return NotFound();
            }
            ViewData["BanquetId"] = new SelectList(_context.BanquetMenus, "BanquetId", "BanquetId", banquetAndMenuItem.BanquetId);
            ViewData["ItemId"] = new SelectList(_context.MenuItems, "ItemId", "ItemId", banquetAndMenuItem.ItemId);
            return View(banquetAndMenuItem);
        }

        // POST: BanquetAndMenuItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BanquetAndMenuItemsId,ItemId,BanquetId")] BanquetAndMenuItem banquetAndMenuItem)
        {
            if (id != banquetAndMenuItem.BanquetAndMenuItemsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(banquetAndMenuItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BanquetAndMenuItemExists(banquetAndMenuItem.BanquetAndMenuItemsId))
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
            ViewData["BanquetId"] = new SelectList(_context.BanquetMenus, "BanquetId", "BanquetId", banquetAndMenuItem.BanquetId);
            ViewData["ItemId"] = new SelectList(_context.MenuItems, "ItemId", "ItemId", banquetAndMenuItem.ItemId);
            return View(banquetAndMenuItem);
        }

        // GET: BanquetAndMenuItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BanquetAndMenuItems == null)
            {
                return NotFound();
            }

            var banquetAndMenuItem = await _context.BanquetAndMenuItems
                .Include(b => b.Banquet)
                .Include(b => b.Item)
                .FirstOrDefaultAsync(m => m.BanquetAndMenuItemsId == id);
            if (banquetAndMenuItem == null)
            {
                return NotFound();
            }

            return View(banquetAndMenuItem);
        }

        // POST: BanquetAndMenuItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BanquetAndMenuItems == null)
            {
                return Problem("Entity set 'SVGRestaurantContext.BanquetAndMenuItems'  is null.");
            }
            var banquetAndMenuItem = await _context.BanquetAndMenuItems.FindAsync(id);
            if (banquetAndMenuItem != null)
            {
                _context.BanquetAndMenuItems.Remove(banquetAndMenuItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BanquetAndMenuItemExists(int id)
        {
          return (_context.BanquetAndMenuItems?.Any(e => e.BanquetAndMenuItemsId == id)).GetValueOrDefault();
        }
    }
}
