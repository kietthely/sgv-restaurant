using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace SGVRestaurantProject.Controllers
{
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        [HttpGet]
        public IActionResult ListAllRoles()
        {
            var roles = _roleManager.Roles;

            return View(roles);
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
    }
}
