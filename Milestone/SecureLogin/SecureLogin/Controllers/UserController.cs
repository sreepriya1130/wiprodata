using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SecureLoginRoleBasedMVC.Models;


namespace SecureLoginRoleBasedMVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public UserController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }


        public async Task<IActionResult> Profile()
        {
            ViewBag.Message = TempData["Message"] ?? "";
            var user = await _userManager.GetUserAsync(User);
            return View(user);
        }
    }
}