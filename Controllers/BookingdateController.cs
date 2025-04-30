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
    public class BookingdateController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public BookingdateController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Bookingdate
        public async Task<IActionResult> Index()
        {
            return View(await _context.Bookingdates.ToListAsync());
        }

        // GET: Bookingdate/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingdate = await _context.Bookingdates
                .FirstOrDefaultAsync(m => m.Bookingid == id);
            if (bookingdate == null)
            {
                return NotFound();
            }

            return View(bookingdate);
        }

        // GET: Bookingdate/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bookingdate/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bookingid,Checkindate,Checkoutdate")] Bookingdate bookingdate)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookingdate);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bookingdate);
        }

        // GET: Bookingdate/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingdate = await _context.Bookingdates.FindAsync(id);
            if (bookingdate == null)
            {
                return NotFound();
            }
            return View(bookingdate);
        }

        // POST: Bookingdate/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Bookingid,Checkindate,Checkoutdate")] Bookingdate bookingdate)
        {
            if (id != bookingdate.Bookingid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookingdate);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingdateExists(bookingdate.Bookingid))
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
            return View(bookingdate);
        }

        // GET: Bookingdate/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookingdate = await _context.Bookingdates
                .FirstOrDefaultAsync(m => m.Bookingid == id);
            if (bookingdate == null)
            {
                return NotFound();
            }

            return View(bookingdate);
        }

        // POST: Bookingdate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookingdate = await _context.Bookingdates.FindAsync(id);
            if (bookingdate != null)
            {
                _context.Bookingdates.Remove(bookingdate);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingdateExists(int id)
        {
            return _context.Bookingdates.Any(e => e.Bookingid == id);
        }
    }
}
