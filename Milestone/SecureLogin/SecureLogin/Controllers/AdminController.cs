using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureLoginRoleBasedMVC.Models;


namespace SecureLoginRoleBasedMVC.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public AdminController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public IActionResult Dashboard()
        {
            ViewBag.Message = TempData["Message"] ?? "";
            var users = _userManager.Users.ToList();
            return View(users);
        }
    }
}