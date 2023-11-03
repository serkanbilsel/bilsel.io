using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serkanbilsel.Data;
using serkanbilsel.Entities;
using serkanbilsel.Models;
using System.Diagnostics;

namespace serkanbilsel.Controllers
{
    public class HomeController : Controller
    {
        private readonly DatabaseContext _context;

        public HomeController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new HomePageViewModel()
            {
                News = await _context.News.Where(p => p.IsActive && p.IsHome).ToListAsync(),
              
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ContactUsAsync(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _context.Contacts.AddAsync(contact);
                    await _context.SaveChangesAsync();
                    TempData["Mesaj"] = "<div class = 'alert alert-danger'>Mesajınız Gönderildi.. Teşekkürler..</div>";
                    return RedirectToAction("ContactUs");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Hata Oluştu!.");
                }
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}