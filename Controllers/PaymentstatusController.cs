using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HTM.Models;

namespace HTM.Controllers
{
    public class PaymentstatusController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public PaymentstatusController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Paymentstatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Paymentstatuses.ToListAsync());
        }

        // GET: Paymentstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentstatus = await _context.Paymentstatuses
                .FirstOrDefaultAsync(m => m.Statusid == id);
            if (paymentstatus == null)
            {
                return NotFound();
            }

            return View(paymentstatus);
        }

        // GET: Paymentstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Paymentstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Statusid,Statusname")] Paymentstatus paymentstatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(paymentstatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(paymentstatus);
        }

        // GET: Paymentstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentstatus = await _context.Paymentstatuses.FindAsync(id);
            if (paymentstatus == null)
            {
                return NotFound();
            }
            return View(paymentstatus);
        }

        // POST: Paymentstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Statusid,Statusname")] Paymentstatus paymentstatus)
        {
            if (id != paymentstatus.Statusid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(paymentstatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PaymentstatusExists(paymentstatus.Statusid))
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
            return View(paymentstatus);
        }

        // GET: Paymentstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var paymentstatus = await _context.Paymentstatuses
                .FirstOrDefaultAsync(m => m.Statusid == id);
            if (paymentstatus == null)
            {
                return NotFound();
            }

            return View(paymentstatus);
        }

        // POST: Paymentstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var paymentstatus = await _context.Paymentstatuses.FindAsync(id);
            if (paymentstatus != null)
            {
                _context.Paymentstatuses.Remove(paymentstatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PaymentstatusExists(int id)
        {
            return _context.Paymentstatuses.Any(e => e.Statusid == id);
        }
    }
}
