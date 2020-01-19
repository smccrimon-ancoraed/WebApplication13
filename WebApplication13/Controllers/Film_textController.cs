using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Data;
using WebApplication13.Models;

namespace WebApplication13.Controllers
{
    public class Film_textController : Controller
    {
        private readonly ApplicationDbContext _context;

        public Film_textController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Film_text
        public async Task<IActionResult> Index()
        {
            return View(await _context.Film_text.ToListAsync());
        }

        // GET: Film_text/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film_text = await _context.Film_text
                .FirstOrDefaultAsync(m => m.Film_id == id);
            if (film_text == null)
            {
                return NotFound();
            }

            return View(film_text);
        }

        // GET: Film_text/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Film_text/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Film_id,Title,Description")] Film_text film_text)
        {
            if (ModelState.IsValid)
            {
                _context.Add(film_text);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(film_text);
        }

        // GET: Film_text/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film_text = await _context.Film_text.FindAsync(id);
            if (film_text == null)
            {
                return NotFound();
            }
            return View(film_text);
        }

        // POST: Film_text/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("Film_id,Title,Description")] Film_text film_text)
        {
            if (id != film_text.Film_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(film_text);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Film_textExists(film_text.Film_id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(film_text);
        }

        // GET: Film_text/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var film_text = await _context.Film_text
                .FirstOrDefaultAsync(m => m.Film_id == id);
            if (film_text == null)
            {
                return NotFound();
            }

            return View(film_text);
        }

        // POST: Film_text/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var film_text = await _context.Film_text.FindAsync(id);
            _context.Film_text.Remove(film_text);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Film_textExists(short id)
        {
            return _context.Film_text.Any(e => e.Film_id == id);
        }
    }
}
