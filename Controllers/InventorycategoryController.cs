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
    public class InventorycategoryController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public InventorycategoryController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Inventorycategory
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inventorycategories.ToListAsync());
        }

        // GET: Inventorycategory/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventorycategory = await _context.Inventorycategories
                .FirstOrDefaultAsync(m => m.Categoryid == id);
            if (inventorycategory == null)
            {
                return NotFound();
            }

            return View(inventorycategory);
        }

        // GET: Inventorycategory/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inventorycategory/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Categoryid,Categoryname")] Inventorycategory inventorycategory)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inventorycategory);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inventorycategory);
        }

        // GET: Inventorycategory/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventorycategory = await _context.Inventorycategories.FindAsync(id);
            if (inventorycategory == null)
            {
                return NotFound();
            }
            return View(inventorycategory);
        }

        // POST: Inventorycategory/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Categoryid,Categoryname")] Inventorycategory inventorycategory)
        {
            if (id != inventorycategory.Categoryid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inventorycategory);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InventorycategoryExists(inventorycategory.Categoryid))
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
            return View(inventorycategory);
        }

        // GET: Inventorycategory/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inventorycategory = await _context.Inventorycategories
                .FirstOrDefaultAsync(m => m.Categoryid == id);
            if (inventorycategory == null)
            {
                return NotFound();
            }

            return View(inventorycategory);
        }

        // POST: Inventorycategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inventorycategory = await _context.Inventorycategories.FindAsync(id);
            if (inventorycategory != null)
            {
                _context.Inventorycategories.Remove(inventorycategory);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InventorycategoryExists(int id)
        {
            return _context.Inventorycategories.Any(e => e.Categoryid == id);
        }
    }
}
