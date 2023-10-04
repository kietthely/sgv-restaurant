using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SGVRestaurantProject.Models;
using SGVRestaurantProject.Models.Users;

namespace SGVRestaurantProject.Controllers
{
    public class UserAchievementsController : Controller
    {
        private readonly SVGRestaurantContext _context;
        private readonly UserManager<DefaultUser> _userManager;

        public UserAchievementsController(UserManager<DefaultUser> userManager, SVGRestaurantContext context)
        {
            _context = context;
            _userManager = userManager;
        }



        // GET: UserAchievements
        public async Task<IActionResult> Index(string? userName, UserAchievementsVM uavm)
        {
            #region populate user achievements
            var currentUser = await _userManager.FindByNameAsync(userName);
            var userId = currentUser.Id;

            var userAchievements = await _context.UserAchievements
                .Where(ua => ua.User.Id == userId)
                .ToListAsync();
            uavm.UserAchievements = userAchievements;
            #endregion

            #region populate all achievements
            var allAchievements = await _context.Achievements
                .ToListAsync();

            uavm.AllAchievements = allAchievements;
            #endregion

            return View(uavm);

        }

        // GET: UserAchievements/Details/5
        public async Task<IActionResult> Details(int? id)
        {


            if (id == null || _context.UserAchievements == null)
            {
                return NotFound();
            }

            var userAchievements = await _context.UserAchievements
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserAchievementsId == id);
            if (userAchievements == null)
            {
                return NotFound();
            }

            return View(userAchievements);
        }

        // GET: UserAchievements/Create
        public IActionResult Create()
        {
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id");
            return View();
        }

        // POST: UserAchievements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserAchievementsId,UserId,AchievementId")] UserAchievements userAchievements)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAchievements);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userAchievements.UserId);
            return View(userAchievements);
        }

        // GET: UserAchievements/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.UserAchievements == null)
            {
                return NotFound();
            }

            var userAchievements = await _context.UserAchievements.FindAsync(id);
            if (userAchievements == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userAchievements.UserId);
            return View(userAchievements);
        }

        // POST: UserAchievements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserAchievementsId,UserId,AchievementId")] UserAchievements userAchievements)
        {
            if (id != userAchievements.UserAchievementsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userAchievements);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserAchievementsExists(userAchievements.UserAchievementsId))
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
            ViewData["UserId"] = new SelectList(_context.Users, "Id", "Id", userAchievements.UserId);
            return View(userAchievements);
        }

        // GET: UserAchievements/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.UserAchievements == null)
            {
                return NotFound();
            }

            var userAchievements = await _context.UserAchievements
                .Include(u => u.User)
                .FirstOrDefaultAsync(m => m.UserAchievementsId == id);
            if (userAchievements == null)
            {
                return NotFound();
            }

            return View(userAchievements);
        }

        // POST: UserAchievements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.UserAchievements == null)
            {
                return Problem("Entity set 'SVGRestaurantContext.UserAchievements'  is null.");
            }
            var userAchievements = await _context.UserAchievements.FindAsync(id);
            if (userAchievements != null)
            {
                _context.UserAchievements.Remove(userAchievements);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UserAchievementsExists(int id)
        {
            return (_context.UserAchievements?.Any(e => e.UserAchievementsId == id)).GetValueOrDefault();
        }
    }
}
