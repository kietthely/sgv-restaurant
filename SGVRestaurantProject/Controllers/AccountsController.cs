using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SGVRestaurantProject.Models;
using SGVRestaurantProject.ViewModels;

namespace SGVRestaurantProject.Controllers
{
    public class AccountsController : Controller
    {
        private readonly SVGRestaurantContext _context;
        public AccountsController(SVGRestaurantContext context)
        {
            _context = context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginDetailsViewModel loginDetails)
        {
            if (ModelState.IsValid)
            {
                var user = _context.UserAccounts
                    .Where(ua => ua.UserId.Equals(loginDetails.UserId) &&
                    ua.EmailAddress.Equals(loginDetails.EmailAddress))
                    .FirstOrDefault();
                if (user != null)
                {
                    HttpContext.Session.SetString("UserType", user.UserType);
                    return RedirectToAction("Logedin", user);
                }
            }
            return View();
        }
        public IActionResult Logedin(UserAccount userAccount)
        {
            return View(userAccount);
        }

        public IActionResult Register()
        {
            ViewData["UserId"] = new SelectList(_context.UserAccounts, "UserId", "UserId");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserId,UserType,EmailAddress,PhoneNumber")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                _context.Add(userAccount);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Login));
            }

            ViewData["UserId"] = new SelectList(_context.UserAccounts, "UserId", "UserId", userAccount.UserId);
            return View(userAccount);
        }
    }
}
