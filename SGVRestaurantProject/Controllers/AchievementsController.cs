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
    public class AchievementsController : Controller
    {
        private readonly SVGRestaurantContext _context;

        public AchievementsController(SVGRestaurantContext context)
        {
            _context = context;
        }

        // GET: Achievements
        public async Task<IActionResult> Index()
        {
              return _context.Achievements != null ? 
                          View(await _context.Achievements.ToListAsync()) :
                          Problem("Entity set 'SVGRestaurantContext.Achievements'  is null.");
        }

        // GET: Achievements/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievements = await _context.Achievements
                .FirstOrDefaultAsync(m => m.AchievementId == id);
            if (achievements == null)
            {
                return NotFound();
            }

            return View(achievements);
        }

        // GET: Achievements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Achievements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AchievementId,AchievementName")] Achievements achievements)
        {
            _context.Add(achievements);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Achievements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievements = await _context.Achievements.FindAsync(id);
            if (achievements == null)
            {
                return NotFound();
            }
            return View(achievements);
        }

        // POST: Achievements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AchievementId,AchievementName")] Achievements achievements)
        {
            if (id != achievements.AchievementId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(achievements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AchievementsExists(achievements.AchievementId))
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
            return View(achievements);
        }

        // GET: Achievements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Achievements == null)
            {
                return NotFound();
            }

            var achievements = await _context.Achievements
                .FirstOrDefaultAsync(m => m.AchievementId == id);
            if (achievements == null)
            {
                return NotFound();
            }

            return View(achievements);
        }

        // POST: Achievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Achievements == null)
            {
                return Problem("Entity set 'SVGRestaurantContext.Achievements'  is null.");
            }
            var achievements = await _context.Achievements.FindAsync(id);
            if (achievements != null)
            {
                _context.Achievements.Remove(achievements);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AchievementsExists(int id)
        {
          return (_context.Achievements?.Any(e => e.AchievementId == id)).GetValueOrDefault();
        }
    }
}
