using Microsoft.AspNetCore.Mvc;

namespace RoleBasedProductMgmt.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index() => View();
    }
}
