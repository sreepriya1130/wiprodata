using Microsoft.AspNetCore.Mvc;


namespace SecureLoginRoleBasedMVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}