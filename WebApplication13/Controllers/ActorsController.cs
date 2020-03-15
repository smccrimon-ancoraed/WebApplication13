using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication13.Data;
using WebApplication13.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

using Microsoft.AspNetCore.Http;


namespace WebApplication13.Controllers
{
    [Authorize]
    public class ActorsController : Controller
    {

        private readonly ApplicationDbContext _context;

      //  string _myuser = this.User.Identity.Name;
      

        public ActorsController(ApplicationDbContext context)
        {
            _context = context;
        }


        // Search by First or Last name
        public async  Task<IActionResult> Index(string searchString)
        {
            //  ApplicationDbContext dbcurr = new ApplicationDbContext();
            //var _userId = dbcurr.Users..AspNetUsers.FirstOrDefault(u => u.Id == TableName.ApsNetUserId);

      

           var actor = from m in _context.Actor select m;
                                                                                                                                                                                                                           
            string _name = User.Identity.Name;
            string _nameId = new ApplicationUser().Id;
            string _nameUser = new ApplicationUser().UserName;

            
            // searchString = _name;
            if (!String.IsNullOrEmpty(searchString))
            {
                
                actor = actor.Where(a => a.First_name.Contains(searchString)
                || a.Last_name.Contains(searchString));
                //Logical operator !! = OR     && = AND   ! = NOT
            }

            return View(await actor.ToListAsync());
        }


        


        // GET: Actors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor
                .FirstOrDefaultAsync(m => m.Actor_id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // GET: Actors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Actor_id,First_name,Last_name,Last_update")] Actor actor)
        {

            DateTime tmpdate = DateTime.Now;  // Get the current date-timestamp
            if (ModelState.IsValid)
            {
                actor.Last_update = tmpdate;
                _context.Add(actor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(actor);
        }

        // GET: Actors/Edit/5
        [Authorize(Roles = "Administrator, Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor.FindAsync(id);
            if (actor == null)
            {
                return NotFound();
            }
            return View(actor);
        }

        // POST: Actors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Actor_id,First_name,Last_name,Last_update")] Actor actor)
        {
            if (id != actor.Actor_id)
            {
                return NotFound();
            }
            DateTime tmpdate = DateTime.Now;  // Get the current date-timestamp
            if (ModelState.IsValid)
            {
                try
                {
                    actor.Last_update = tmpdate;
                    _context.Update(actor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ActorExists(actor.Actor_id))
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
            return View(actor);
        }

        [Authorize(Policy = "RequireAdministratorRole")]
        // GET: Actors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var actor = await _context.Actor
                .FirstOrDefaultAsync(m => m.Actor_id == id);
            if (actor == null)
            {
                return NotFound();
            }

            return View(actor);
        }

        // POST: Actors/Delete/5
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actor = await _context.Actor.FindAsync(id);
            _context.Actor.Remove(actor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ActorExists(int id)
        {
            return _context.Actor.Any(e => e.Actor_id == id);
        }
    }
}
