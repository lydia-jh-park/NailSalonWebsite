using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunnyNails.Data;
using FunnyNails.Models.Customer;
using Microsoft.AspNetCore.Authorization;

namespace FunnyNails.Controllers.Customer
{
    [Authorize(Roles = "Customer")]
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            return View(await _context.AppointmentMgmt.ToListAsync());
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentMgmt = await _context.AppointmentMgmt
                .SingleOrDefaultAsync(m => m.AppointmentID == id);
            if (appointmentMgmt == null)
            {
                return NotFound();
            }

            return View(appointmentMgmt);
        }

        // GET: Appointment/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Appointment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AppointmentID,AppointmentDate,EmpName,Rating")] AppointmentMgmt appointmentMgmt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(appointmentMgmt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(appointmentMgmt);
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentMgmt = await _context.AppointmentMgmt.SingleOrDefaultAsync(m => m.AppointmentID == id);
            if (appointmentMgmt == null)
            {
                return NotFound();
            }
            return View(appointmentMgmt);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AppointmentID,AppointmentDate,EmpName,Rating")] AppointmentMgmt appointmentMgmt)
        {
            if (id != appointmentMgmt.AppointmentID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointmentMgmt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentMgmtExists(appointmentMgmt.AppointmentID))
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
            return View(appointmentMgmt);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointmentMgmt = await _context.AppointmentMgmt
                .SingleOrDefaultAsync(m => m.AppointmentID == id);
            if (appointmentMgmt == null)
            {
                return NotFound();
            }

            return View(appointmentMgmt);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointmentMgmt = await _context.AppointmentMgmt.SingleOrDefaultAsync(m => m.AppointmentID == id);
            _context.AppointmentMgmt.Remove(appointmentMgmt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentMgmtExists(int id)
        {
            return _context.AppointmentMgmt.Any(e => e.AppointmentID == id);
        }
    }
}
