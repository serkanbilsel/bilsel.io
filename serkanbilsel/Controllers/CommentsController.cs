using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using serkanbilsel.Data;
using serkanbilsel.Models;

namespace serkanbilsel.Controllers
{
    public class CommentsController : Controller
    {
      

        private readonly DatabaseContext _context;

        public CommentsController(DatabaseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var yorumlar = await _context.Comments.ToListAsync();
            return View(yorumlar);
        }

        public IActionResult AddComment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(Comment comment)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    comment.CreateDate = DateTime.Now;
                    comment.Approved = false; // Yorumlar otomatik olarak onaylanmamış olarak işaretlendi.
                    _context.Comments.Add(comment);
                    await _context.SaveChangesAsync();
                    TempData["Mesaj"] = "<div class='alert alert-danger'>Your comment has been sent for approval.</div>";
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Something Wrong!.");
                }
            }
            return View(comment);
        }


        public async Task<IActionResult> AddLike(int commentId)
        {
            var comment = await _context.Comments.FindAsync(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            comment.LikeCount++;
            _context.Update(comment);

            var likes = new Likes { CommentId = commentId};
            _context.Likes.Add(likes);

            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }





    }
}
