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
    public class HousekeepingController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public HousekeepingController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Housekeeping
        public async Task<IActionResult> Index()
        {
            var hmanagementSystemdbContext = _context.Housekeepings.Include(h => h.Room);
            return View(await hmanagementSystemdbContext.ToListAsync());
        }

        // GET: Housekeeping/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housekeeping = await _context.Housekeepings
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.Taskid == id);
            if (housekeeping == null)
            {
                return NotFound();
            }

            return View(housekeeping);
        }

        // GET: Housekeeping/Create
        public IActionResult Create()
        {
            ViewData["Roomid"] = new SelectList(_context.Rooms, "Roomid", "Roomid");
            return View();
        }

        // POST: Housekeeping/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Taskid,Roomid,Taskdescription,Taskdate")] Housekeeping housekeeping)
        {
            if (ModelState.IsValid)
            {
                _context.Add(housekeeping);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Roomid"] = new SelectList(_context.Rooms, "Roomid", "Roomid", housekeeping.Roomid);
            return View(housekeeping);
        }

        // GET: Housekeeping/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housekeeping = await _context.Housekeepings.FindAsync(id);
            if (housekeeping == null)
            {
                return NotFound();
            }
            ViewData["Roomid"] = new SelectList(_context.Rooms, "Roomid", "Roomid", housekeeping.Roomid);
            return View(housekeeping);
        }

        // POST: Housekeeping/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Taskid,Roomid,Taskdescription,Taskdate")] Housekeeping housekeeping)
        {
            if (id != housekeeping.Taskid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(housekeeping);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HousekeepingExists(housekeeping.Taskid))
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
            ViewData["Roomid"] = new SelectList(_context.Rooms, "Roomid", "Roomid", housekeeping.Roomid);
            return View(housekeeping);
        }

        // GET: Housekeeping/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var housekeeping = await _context.Housekeepings
                .Include(h => h.Room)
                .FirstOrDefaultAsync(m => m.Taskid == id);
            if (housekeeping == null)
            {
                return NotFound();
            }

            return View(housekeeping);
        }

        // POST: Housekeeping/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var housekeeping = await _context.Housekeepings.FindAsync(id);
            if (housekeeping != null)
            {
                _context.Housekeepings.Remove(housekeeping);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HousekeepingExists(int id)
        {
            return _context.Housekeepings.Any(e => e.Taskid == id);
        }
    }
}
