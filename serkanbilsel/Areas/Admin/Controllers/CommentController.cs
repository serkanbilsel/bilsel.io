using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serkanbilsel.Data;
using serkanbilsel.Entities;
using serkanbilsel.Models;

namespace serkanbilsel.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {

        private readonly DatabaseContext _context;

        public CommentController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var comments = await _context.Comments.ToListAsync();
            return View(comments);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveAsync(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                comment.Approved = true;
                _context.Update(comment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }




        [HttpPost]
        public async Task<IActionResult> Delete(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment != null)
            {
                _context.Comments.Remove(comment);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index");
        }

    



}
}
