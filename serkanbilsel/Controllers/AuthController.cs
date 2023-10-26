using Microsoft.AspNetCore.Mvc;

namespace serkanbilsel.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
