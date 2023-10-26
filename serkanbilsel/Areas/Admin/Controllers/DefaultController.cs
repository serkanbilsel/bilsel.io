using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace serkanbilsel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DefaultController : Controller
    {
        // GET: DefaultController
        public ActionResult Index()
        {
            return View();
        }


    }
}
