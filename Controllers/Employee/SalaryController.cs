using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FunnyNails.Data;
using FunnyNails.Models.Employee;
using Microsoft.AspNetCore.Authorization;

namespace FunnyNails.Controllers.Employee
{
    [Authorize(Roles = "Employee")]
    public class SalaryController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalaryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Salary
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalaryMgmt.ToListAsync());
        }

        // GET: Salary/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryMgmt = await _context.SalaryMgmt
                .SingleOrDefaultAsync(m => m.SalaryID == id);
            if (salaryMgmt == null)
            {
                return NotFound();
            }

            return View(salaryMgmt);
        }

        // GET: Salary/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalaryID,Salary")] SalaryMgmt salaryMgmt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salaryMgmt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salaryMgmt);
        }

        // GET: Salary/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryMgmt = await _context.SalaryMgmt.SingleOrDefaultAsync(m => m.SalaryID == id);
            if (salaryMgmt == null)
            {
                return NotFound();
            }
            return View(salaryMgmt);
        }

        // POST: Salary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalaryID,Salary")] SalaryMgmt salaryMgmt)
        {
            if (id != salaryMgmt.SalaryID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salaryMgmt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalaryMgmtExists(salaryMgmt.SalaryID))
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
            return View(salaryMgmt);
        }

        // GET: Salary/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salaryMgmt = await _context.SalaryMgmt
                .SingleOrDefaultAsync(m => m.SalaryID == id);
            if (salaryMgmt == null)
            {
                return NotFound();
            }

            return View(salaryMgmt);
        }

        // POST: Salary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salaryMgmt = await _context.SalaryMgmt.SingleOrDefaultAsync(m => m.SalaryID == id);
            _context.SalaryMgmt.Remove(salaryMgmt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalaryMgmtExists(int id)
        {
            return _context.SalaryMgmt.Any(e => e.SalaryID == id);
        }
    }
}
