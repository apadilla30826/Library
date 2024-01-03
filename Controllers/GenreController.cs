using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class GenreController : Controller
    {
        private readonly LibraryContext _context;
        public GenreController(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Genres.ToListAsync());
        }
        public IActionResult Create()
        {
            ViewData["Genres"] = new SelectList(_context.Genres, "genre_id", "genre_name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Genre model)
        {
            if (ModelState.IsValid)
            {
                var genre = new Genre()
                {
                    GenreId = _context.Genres.Max(p => p.GenreId) + 1,
                    GenreName = model.GenreName,
                };
                _context.Genres.Add(genre);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Genres"] = new SelectList(_context.Genres, "genre_id", "genre_name");
            return View();
        }
    }
}
