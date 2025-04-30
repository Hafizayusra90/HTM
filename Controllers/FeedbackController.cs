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
    public class FeedbackController : Controller
    {
        private readonly HmanagementSystemdbContext _context;

        public FeedbackController(HmanagementSystemdbContext context)
        {
            _context = context;
        }

        // GET: Feedback
        public async Task<IActionResult> Index()
        {
            var hmanagementSystemdbContext = _context.Feedbacks.Include(f => f.Guest).Include(f => f.Service);
            return View(await hmanagementSystemdbContext.ToListAsync());
        }

        // GET: Feedback/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .Include(f => f.Guest)
                .Include(f => f.Service)
                .FirstOrDefaultAsync(m => m.Feedbackid == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // GET: Feedback/Create
        public IActionResult Create()
        {
            ViewData["Guestid"] = new SelectList(_context.Guests, "Guestid", "Guestid");
            ViewData["Serviceid"] = new SelectList(_context.Services, "Serviceid", "Serviceid");
            return View();
        }

        // POST: Feedback/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Feedbackid,Guestid,Fbdate,Serviceid,Rating,Commentt")] Feedback feedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Guestid"] = new SelectList(_context.Guests, "Guestid", "Guestid", feedback.Guestid);
            ViewData["Serviceid"] = new SelectList(_context.Services, "Serviceid", "Serviceid", feedback.Serviceid);
            return View(feedback);
        }

        // GET: Feedback/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback == null)
            {
                return NotFound();
            }
            ViewData["Guestid"] = new SelectList(_context.Guests, "Guestid", "Guestid", feedback.Guestid);
            ViewData["Serviceid"] = new SelectList(_context.Services, "Serviceid", "Serviceid", feedback.Serviceid);
            return View(feedback);
        }

        // POST: Feedback/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Feedbackid,Guestid,Fbdate,Serviceid,Rating,Commentt")] Feedback feedback)
        {
            if (id != feedback.Feedbackid)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeedbackExists(feedback.Feedbackid))
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
            ViewData["Guestid"] = new SelectList(_context.Guests, "Guestid", "Guestid", feedback.Guestid);
            ViewData["Serviceid"] = new SelectList(_context.Services, "Serviceid", "Serviceid", feedback.Serviceid);
            return View(feedback);
        }

        // GET: Feedback/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feedback = await _context.Feedbacks
                .Include(f => f.Guest)
                .Include(f => f.Service)
                .FirstOrDefaultAsync(m => m.Feedbackid == id);
            if (feedback == null)
            {
                return NotFound();
            }

            return View(feedback);
        }

        // POST: Feedback/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feedback = await _context.Feedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.Feedbacks.Remove(feedback);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeedbackExists(int id)
        {
            return _context.Feedbacks.Any(e => e.Feedbackid == id);
        }
    }
}
