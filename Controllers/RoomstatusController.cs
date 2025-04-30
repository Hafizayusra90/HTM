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
    public class RoomstatusController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public RoomstatusController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Roomstatus
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roomstatuses.ToListAsync());
        }

        // GET: Roomstatus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomstatus = await _context.Roomstatuses
                .FirstOrDefaultAsync(m => m.Statusid == id);
            if (roomstatus == null)
            {
                return NotFound();
            }

            return View(roomstatus);
        }

        // GET: Roomstatus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roomstatus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Statusid,Statusname")] Roomstatus roomstatus)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomstatus);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomstatus);
        }

        // GET: Roomstatus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomstatus = await _context.Roomstatuses.FindAsync(id);
            if (roomstatus == null)
            {
                return NotFound();
            }
            return View(roomstatus);
        }

        // POST: Roomstatus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Statusid,Statusname")] Roomstatus roomstatus)
        {
            if (id != roomstatus.Statusid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomstatus);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomstatusExists(roomstatus.Statusid))
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
            return View(roomstatus);
        }

        // GET: Roomstatus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomstatus = await _context.Roomstatuses
                .FirstOrDefaultAsync(m => m.Statusid == id);
            if (roomstatus == null)
            {
                return NotFound();
            }

            return View(roomstatus);
        }

        // POST: Roomstatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomstatus = await _context.Roomstatuses.FindAsync(id);
            if (roomstatus != null)
            {
                _context.Roomstatuses.Remove(roomstatus);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomstatusExists(int id)
        {
            return _context.Roomstatuses.Any(e => e.Statusid == id);
        }
    }
}
