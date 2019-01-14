using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunnyNails.Data;
using FunnyNails.Models.Employee;
using Microsoft.AspNetCore.Authorization;

namespace FunnyNails.Controllers.Employee
{
    [Authorize(Roles = "Employee")]
    public class CurWageController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CurWageController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CurWage
        public async Task<IActionResult> Index()
        {
            return View(await _context.CurWageMgmt.ToListAsync());
        }

        // GET: CurWage/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var curWageMgmt = await _context.CurWageMgmt.SingleOrDefaultAsync(m => m.CurWageID == id);
            if (curWageMgmt == null)
            {
                return NotFound();
            }
            return View(curWageMgmt);
        }

        // POST: CurWage/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CurWageID,CurWage")] CurWageMgmt curWageMgmt)
        {
            if (id != curWageMgmt.CurWageID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(curWageMgmt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CurWageMgmtExists(curWageMgmt.CurWageID))
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
            return View(curWageMgmt);
        }

        private bool CurWageMgmtExists(int id)
        {
            return _context.CurWageMgmt.Any(e => e.CurWageID == id);
        }
    }
}
