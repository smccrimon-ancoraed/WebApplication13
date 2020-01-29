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

namespace WebApplication13.Controllers
{
    // [AllowAnonymous]
    [Authorize]
    public class RentalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RentalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rentals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Rental.ToListAsync());
        }

        // GET: Rentals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .FirstOrDefaultAsync(m => m.Rental_id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // GET: Rentals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rentals/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Rental_id,Rental_date,Inventory_id,Customer_id,Return_date,Staff_id,Last_update")] Rental rental)
        {
            DateTime tmpdate = DateTime.Now; // DataTime.Today returns the date.  DateTime.UTCNow.Date
            // DateTime.Now shows yyyy-mm-dd hh:mm:ss
            // DateTime.UTCNow shows
            // SQL Srv DateTime format is 2006-02-15 21:30:53.000  yyyy-mm-dd hh:mm:ss.nnn

            if (ModelState.IsValid)
            {
                rental.Last_update = tmpdate;
                _context.Add(rental);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rental);
        }

        [Authorize(Roles = "Administrator, Manager")]
        // GET: Rentals/Edit/5
       // [Authorize(Policy = "RequireAdministratorRole")]
        //[Authorize(Policy = "SupervisorRole")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental.FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }
            return View(rental);
        }

        // POST: Rentals/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
         [Authorize(Roles = "Administrator, Manager")]
        // error below at runtime
      //  [Authorize(Policy = "RequireAdministratorRole, SupervisorRole")]
      //   [Authorize(Policy = "RequireAdministratorRole")]
      //  [Authorize(Policy = "SupervisorRole")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Rental_id,Rental_date,Inventory_id,Customer_id,Return_date,Staff_id,Last_update")] Rental rental)
        {
            DateTime tmpdate = DateTime.Now; // DataTime.Today returns the date.  DateTime.UTCNow.Date

            if (id != rental.Rental_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    rental.Last_update = tmpdate;
                //    rental.Last_update = DateTime.UtcNow;
                    _context.Update(rental);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RentalExists(rental.Rental_id))
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
            return View(rental);
        }

        // GET: Rentals/Delete/5
        // [Authorize(Roles = "Administrator, Manager")]
        [Authorize(Policy = "RequireAdministratorRole")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rental = await _context.Rental
                .FirstOrDefaultAsync(m => m.Rental_id == id);
            if (rental == null)
            {
                return NotFound();
            }

            return View(rental);
        }

        // POST: Rentals/Delete/5
        // [Authorize(Roles = "Administrator, Manager")]
        [Authorize(Policy = "RequireAdministratorRole")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rental = await _context.Rental.FindAsync(id);
            _context.Rental.Remove(rental);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RentalExists(int id)
        {
            return _context.Rental.Any(e => e.Rental_id == id);
        }
    }
}
