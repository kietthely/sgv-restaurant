using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Data;
using SGVRestaurantProject.Models;

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
              return _context.BanquetMenus != null ? 
                          View(await _context.BanquetMenus.ToListAsync()) :
                          Problem("Entity set 'SVGRestaurantContext.BanquetMenus'  is null.");
        }

        // GET: BanquetMenus/Details/5
        public async Task<IActionResult> Details(int? id)
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
            if (ModelState.IsValid)
            {
                _context.Add(banquetMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(banquetMenu);
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
