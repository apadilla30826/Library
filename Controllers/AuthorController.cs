using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class AuthorController : Controller
    {
        private readonly LibraryContext _context;
        public AuthorController(LibraryContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Authors.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewData["Authors"] = new SelectList(_context.Authors,"author_id","author_name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Author model)
        {
            if (ModelState.IsValid)
            {
                
                var author = new Author()
                {
                    AuthorId = _context.Authors.Max(p => p.AuthorId) + 1,
                    AuthorName = model.AuthorName
                };
                _context.Authors.Add(author);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Authors"] = new SelectList(_context.Authors, "author_id", "author_name");
            return View(model);
        }
    }
}
