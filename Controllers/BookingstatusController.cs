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
    public class BookingstatusController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public BookingstatusController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Bookingstatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookingstatuses.ToListAsync());
        }

        // GET: Bookingstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingstatus = await _context.Bookingstatuses
                .FirstOrDefaultAsync(m => m.Statusid == id);
            if (bookingstatus == null)
            {
                return NotFound();
            }

            return View(bookingstatus);
        }

        // GET: Bookingstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookingstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Statusid,Statusname")] Bookingstatus bookingstatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingstatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingstatus);
        }

        // GET: Bookingstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingstatus = await _context.Bookingstatuses.FindAsync(id);
            if (bookingstatus == null)
            {
                return NotFound();
            }
            return View(bookingstatus);
        }

        // POST: Bookingstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Statusid,Statusname")] Bookingstatus bookingstatus)
        {
            if (id != bookingstatus.Statusid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingstatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingstatusExists(bookingstatus.Statusid))
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
            return View(bookingstatus);
        }

        // GET: Bookingstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingstatus = await _context.Bookingstatuses
                .FirstOrDefaultAsync(m => m.Statusid == id);
            if (bookingstatus == null)
            {
                return NotFound();
            }

            return View(bookingstatus);
        }

        // POST: Bookingstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingstatus = await _context.Bookingstatuses.FindAsync(id);
            if (bookingstatus != null)
            {
                _context.Bookingstatuses.Remove(bookingstatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingstatusExists(int id)
        {
            return _context.Bookingstatuses.Any(e => e.Statusid == id);
        }
    }
}
