using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunnyNails.Data;
using FunnyNails.Models;
using Microsoft.AspNetCore.Authorization;

namespace FunnyNails.Controllers.Customer
{
    [Authorize(Roles = "Customer")]
    public class CreditsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CreditsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Credits
        public async Task<IActionResult> Index()
        {
            return View(await _context.CustomerMgmt.ToListAsync());
        }
        
        // GET: Credits/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var customerMgmt = await _context.CustomerMgmt.SingleOrDefaultAsync(m => m.CustomerID == id);
            if (customerMgmt == null)
            {
                return NotFound();
            }
            return View(customerMgmt);
        }

        // POST: Credits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CustomerID,Credits")] CustomerMgmt customerMgmt)
        {
            if (id != customerMgmt.CustomerID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(customerMgmt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CustomerMgmtExists(customerMgmt.CustomerID))
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
            return View(customerMgmt);
        }

        private bool CustomerMgmtExists(int id)
        {
            return _context.CustomerMgmt.Any(e => e.CustomerID == id);
        }
    }
}
