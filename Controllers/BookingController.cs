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
    public class BookingController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public BookingController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Booking
        public async Task<IActionResult> Index()
        {
            var hmanagementSystemdbContext = _context.Bookings.Include(b => b.Guest).Include(b => b.Room).Include(b => b.Status);
            return View(await hmanagementSystemdbContext.ToListAsync());
        }

        // GET: Booking/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(m => m.Bookingid == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // GET: Booking/Create
        public IActionResult Create()
        {
            ViewData["Guestid"] = new SelectList(_context.Guests, "Guestid", "Guestid");
            ViewData["Roomid"] = new SelectList(_context.Rooms, "Roomid", "Roomid");
            ViewData["Statusid"] = new SelectList(_context.Bookingstatuses, "Statusid", "Statusid");
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Bookingid,Guestid,Roomid,Statusid")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Guestid"] = new SelectList(_context.Guests, "Guestid", "Guestid", booking.Guestid);
            ViewData["Roomid"] = new SelectList(_context.Rooms, "Roomid", "Roomid", booking.Roomid);
            ViewData["Statusid"] = new SelectList(_context.Bookingstatuses, "Statusid", "Statusid", booking.Statusid);
            return View(booking);
        }

        // GET: Booking/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings.FindAsync(id);
            if (booking == null)
            {
                return NotFound();
            }
            ViewData["Guestid"] = new SelectList(_context.Guests, "Guestid", "Guestid", booking.Guestid);
            ViewData["Roomid"] = new SelectList(_context.Rooms, "Roomid", "Roomid", booking.Roomid);
            ViewData["Statusid"] = new SelectList(_context.Bookingstatuses, "Statusid", "Statusid", booking.Statusid);
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Bookingid,Guestid,Roomid,Statusid")] Booking booking)
        {
            if (id != booking.Bookingid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Bookingid))
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
            ViewData["Guestid"] = new SelectList(_context.Guests, "Guestid", "Guestid", booking.Guestid);
            ViewData["Roomid"] = new SelectList(_context.Rooms, "Roomid", "Roomid", booking.Roomid);
            ViewData["Statusid"] = new SelectList(_context.Bookingstatuses, "Statusid", "Statusid", booking.Statusid);
            return View(booking);
        }

        // GET: Booking/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var booking = await _context.Bookings
                .Include(b => b.Guest)
                .Include(b => b.Room)
                .Include(b => b.Status)
                .FirstOrDefaultAsync(m => m.Bookingid == id);
            if (booking == null)
            {
                return NotFound();
            }

            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.Bookings.FindAsync(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.Bookings.Any(e => e.Bookingid == id);
        }
    }
}
