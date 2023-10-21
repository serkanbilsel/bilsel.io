using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace serkanbilsel.Controllers
{
    public class PortfolioController : Controller
    {
        // GET: PersonelController
        public ActionResult Index()
        {
            return View();
        }

        // GET: PersonelController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: PersonelController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonelController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonelController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: PersonelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonelController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
