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
    [Authorize(Policy = "RequireAdministratorRole")]
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext _context;
        readonly string mySecret = "mysecret";  //  S1="mylittle-secret" S2='mysecret'

        public CustomersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Customers
        public async Task<IActionResult> Index()
        {
            
            return View(await _context.Customer.ToListAsync());
        }

        // GET: Customers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Customer_id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // GET: Customers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //         public async Task<IActionResult> Create([Bind("Customer_id,Store_id,First_name,Last_name,Email,Address_id,Active,Create_date,Last_update,ENCRYPTBYPASSPHRASE(mySecret,Crcard)")] Customer customer)
        //        public async Task<IActionResult> Create([Bind("Customer_id,Store_id,First_name,Last_name,Email,Address_id,Active,Create_date,Last_update,Crcard")] Customer customer)

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Customer_id,Store_id,First_name,Last_name,Email,Address_id,Active,Create_date,Last_update,ENCRYPTBYPASSPHRASE('mysecret',Crcard")] Customer customer)
        {

            DateTime tmpdate = DateTime.Now;   // Capture the currentn datestamp
            char tmpActive = '1';
            if (ModelState.IsValid)
            {
                customer.Last_update = tmpdate;  //  Assign the current datestamp
                customer.Create_date = tmpdate;
                customer.Active = tmpActive;
               if (customer.Crcard != null)
                {
                    // Convert from string to Varbinary

                }
               else
                {
                    customer.Crcard = null;
                }
               
                //customer.Crcard = Convert(customer.Active);
                _context.Add(customer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //
        //    public async Task<IActionResult> Edit(int id, [Bind("Customer_id,Store_id,First_name,Last_name,Email,Address_id,Active,Create_date,Last_update,Crcard")] Customer customer)
        // DECRYPTBYPASSPHRASE(\"+mySecret+"+"\"Crcard"
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Customer_id,Store_id,First_name,Last_name,Email,Address_id,Active,Create_date,Last_update,CONVERT(varbinary,DECRYPTBYPASSPHRASE('mysecret',Crcard)")] Customer customer)
        {
            DateTime tmpdate = DateTime.Now;
            if (id != customer.Customer_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    customer.Last_update = tmpdate;   // Updated with currentn date and time
                    _context.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerExists(customer.Customer_id))
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
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customer = await _context.Customer
                .FirstOrDefaultAsync(m => m.Customer_id == id);
            if (customer == null)
            {
                return NotFound();
            }

            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var customer = await _context.Customer.FindAsync(id);
            _context.Customer.Remove(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CustomerExists(int id)
        {
            return _context.Customer.Any(e => e.Customer_id == id);
        }
    }
}
