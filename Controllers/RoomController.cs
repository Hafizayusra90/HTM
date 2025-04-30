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
    public class RoomController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public RoomController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Room
        public async Task<IActionResult> Index()
        {
            var hmanagementSystemdbContext = _context.Rooms.Include(r => r.Roomtype).Include(r => r.Status);
            return View(await hmanagementSystemdbContext.ToListAsync());
        }

        // GET: Room/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Roomtype)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Roomid == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Room/Create
        public IActionResult Create()
        {
            ViewData["Roomtypeid"] = new SelectList(_context.Roomytypes, "Roomtypeid", "Roomtypeid");
            ViewData["Statusid"] = new SelectList(_context.Roomstatuses, "Statusid", "Statusid");
            return View();
        }

        // POST: Room/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Roomid,Roomno,Roomtypeid,Floorno,Pricepernight,Statusid")] Room room)
        {
            if (ModelState.IsValid)
            {
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Roomtypeid"] = new SelectList(_context.Roomytypes, "Roomtypeid", "Roomtypeid", room.Roomtypeid);
            ViewData["Statusid"] = new SelectList(_context.Roomstatuses, "Statusid", "Statusid", room.Statusid);
            return View(room);
        }

        // GET: Room/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["Roomtypeid"] = new SelectList(_context.Roomytypes, "Roomtypeid", "Roomtypeid", room.Roomtypeid);
            ViewData["Statusid"] = new SelectList(_context.Roomstatuses, "Statusid", "Statusid", room.Statusid);
            return View(room);
        }

        // POST: Room/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Roomid,Roomno,Roomtypeid,Floorno,Pricepernight,Statusid")] Room room)
        {
            if (id != room.Roomid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Roomid))
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
            ViewData["Roomtypeid"] = new SelectList(_context.Roomytypes, "Roomtypeid", "Roomtypeid", room.Roomtypeid);
            ViewData["Statusid"] = new SelectList(_context.Roomstatuses, "Statusid", "Statusid", room.Statusid);
            return View(room);
        }

        // GET: Room/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.Roomtype)
                .Include(r => r.Status)
                .FirstOrDefaultAsync(m => m.Roomid == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Room/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return _context.Rooms.Any(e => e.Roomid == id);
        }
    }
}
