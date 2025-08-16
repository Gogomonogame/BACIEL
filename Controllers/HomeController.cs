using Microsoft.AspNetCore.Mvc;

namespace College.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
