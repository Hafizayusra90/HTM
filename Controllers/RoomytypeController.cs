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
    public class RoomytypeController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public RoomytypeController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Roomytype
        public async Task<IActionResult> Index()
        {
            return View(await _context.Roomytypes.ToListAsync());
        }

        // GET: Roomytype/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomytype = await _context.Roomytypes
                .FirstOrDefaultAsync(m => m.Roomtypeid == id);
            if (roomytype == null)
            {
                return NotFound();
            }

            return View(roomytype);
        }

        // GET: Roomytype/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Roomytype/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Roomtypeid,Roomtypename,Bedtype")] Roomytype roomytype)
        {
            if (ModelState.IsValid)
            {
                _context.Add(roomytype);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(roomytype);
        }

        // GET: Roomytype/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomytype = await _context.Roomytypes.FindAsync(id);
            if (roomytype == null)
            {
                return NotFound();
            }
            return View(roomytype);
        }

        // POST: Roomytype/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Roomtypeid,Roomtypename,Bedtype")] Roomytype roomytype)
        {
            if (id != roomytype.Roomtypeid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(roomytype);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomytypeExists(roomytype.Roomtypeid))
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
            return View(roomytype);
        }

        // GET: Roomytype/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var roomytype = await _context.Roomytypes
                .FirstOrDefaultAsync(m => m.Roomtypeid == id);
            if (roomytype == null)
            {
                return NotFound();
            }

            return View(roomytype);
        }

        // POST: Roomytype/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var roomytype = await _context.Roomytypes.FindAsync(id);
            if (roomytype != null)
            {
                _context.Roomytypes.Remove(roomytype);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomytypeExists(int id)
        {
            return _context.Roomytypes.Any(e => e.Roomtypeid == id);
        }
    }
}
