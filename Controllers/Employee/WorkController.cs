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
    public class WorkController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Work
        public async Task<IActionResult> Index()
        {
            return View(await _context.WorkMgmt.ToListAsync());
        }

        // GET: Work/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workMgmt = await _context.WorkMgmt
                .SingleOrDefaultAsync(m => m.WorkID == id);
            if (workMgmt == null)
            {
                return NotFound();
            }

            return View(workMgmt);
        }

        // GET: Work/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Work/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("WorkID,WorkDay,WorkStart,WorkEnd")] WorkMgmt workMgmt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workMgmt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workMgmt);
        }

        // GET: Work/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workMgmt = await _context.WorkMgmt.SingleOrDefaultAsync(m => m.WorkID == id);
            if (workMgmt == null)
            {
                return NotFound();
            }
            return View(workMgmt);
        }

        // POST: Work/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("WorkID,WorkDay,WorkStart,WorkEnd")] WorkMgmt workMgmt)
        {
            if (id != workMgmt.WorkID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workMgmt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkMgmtExists(workMgmt.WorkID))
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
            return View(workMgmt);
        }

        // GET: Work/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var workMgmt = await _context.WorkMgmt
                .SingleOrDefaultAsync(m => m.WorkID == id);
            if (workMgmt == null)
            {
                return NotFound();
            }

            return View(workMgmt);
        }

        // POST: Work/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var workMgmt = await _context.WorkMgmt.SingleOrDefaultAsync(m => m.WorkID == id);
            _context.WorkMgmt.Remove(workMgmt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkMgmtExists(int id)
        {
            return _context.WorkMgmt.Any(e => e.WorkID == id);
        }
    }
}
