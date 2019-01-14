using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FunnyNails.Data;
using FunnyNails.Models.Customer;
using FunnyNails.Models;
using Microsoft.AspNetCore.Authorization;

namespace FunnyNails.Controllers.Customer
{
    [Authorize(Roles = "Customer")]
    public class SalesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SalesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sales
        public async Task<IActionResult> Index(string userName, string Password)
        {
            return View(await _context.SalesMgmt.ToListAsync());
        }

        [HttpGet]
        public IActionResult Sum()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Sum(SalesVM model)
        {
            if (ModelState.IsValid)
            {
                decimal getCost = (from c in _context.SalesMgmt
                                   where (c.PurchaseDate.Date >= model.Start.Date && c.PurchaseDate.Date <= model.End.Date)
                                   select c.Cost).Sum();

                ViewBag.Cost = getCost;
            }

            return View();
        }

        // GET: Sales/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMgmt = await _context.SalesMgmt
                                    .SingleOrDefaultAsync(m => m.SalesID == id);
            if (salesMgmt == null)
            {
                return NotFound();
            }

            return View(salesMgmt);
        }

        // GET: Sales/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesID,PurchaseDate,Item,Cost,Discount,SalesRemark,ServiceID")] SalesMgmt salesMgmt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(salesMgmt);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(salesMgmt);
        }

        // GET: Sales/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMgmt = await _context.SalesMgmt.SingleOrDefaultAsync(m => m.SalesID == id);
            if (salesMgmt == null)
            {
                return NotFound();
            }
            return View(salesMgmt);
        }

        // POST: Sales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesID,PurchaseDate,Item,Cost,Discount,SalesRemark,ServiceID")] SalesMgmt salesMgmt)
        {
            if (id != salesMgmt.SalesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salesMgmt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesMgmtExists(salesMgmt.SalesID))
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
            return View(salesMgmt);
        }

        // GET: Sales/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMgmt = await _context.SalesMgmt
                .SingleOrDefaultAsync(m => m.SalesID == id);
            if (salesMgmt == null)
            {
                return NotFound();
            }

            return View(salesMgmt);
        }

        // POST: Sales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesMgmt = await _context.SalesMgmt.SingleOrDefaultAsync(m => m.SalesID == id);
            _context.SalesMgmt.Remove(salesMgmt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet, ActionName("Total Cost")]
        //[ValidateAntiForgeryToken]
        //public ActionResult TotalCost(DateTime startDate, DateTime endDate, SalesVM model)
        //{
        //    var user = _context.SalesMgmt.Cost;

        //    for (DateTime dateTime = startDate;
        //        dateTime < endDate;
        //        dateTime += TimeSpan.FromDays(1))
        //    {
        //        .Add(new MonthlyTotalsVM() { Date = startDate.AddMonths(i) });
        //    }
        //}

        private bool SalesMgmtExists(int id)
        {
            return _context.SalesMgmt.Any(e => e.SalesID == id);
        }
    }
}
