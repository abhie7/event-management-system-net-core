using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventManagementSystem.Context;
using EventManagementSystem.Models;

namespace EventManagementSystem.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventsDbContext _context;

        public EventsController(EventsDbContext context)
        {
            _context = context;
        }

        // GET: Events
        public async Task<IActionResult> Index(string searchString = null)
        {
            var events = from e in _context.eventstables
                select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s =>
                    s.event_name.ToLower().Contains(searchString) ||
                    s.category.Contains(searchString) ||
                    s.start_date.ToString().Contains(searchString) || // Assuming start_date is of type DateTime
                    s.end_date.ToString().Contains(searchString) ||   // Assuming end_date is of type DateTime
                    s.venue.Contains(searchString) ||
                    s.status.Contains(searchString) ||
                    s.booking_user_name.Contains(searchString)
                );
            }
            return View(await events.ToListAsync());
        }


        // GET: Events/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventstable = await _context.eventstables
                .FirstOrDefaultAsync(m => m.event_id == id);
            if (eventstable == null)
            {
                return NotFound();
            }

            return View(eventstable);
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Events/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("event_id,event_name,category,start_date,end_date,venue,status,booking_user_name")] eventstable eventstable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(eventstable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(eventstable);
        }

        // GET: Events/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventstable = await _context.eventstables.FindAsync(id);
            if (eventstable == null)
            {
                return NotFound();
            }
            return View(eventstable);
        }

        // POST: Events/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("event_id,event_name,category,start_date,end_date,venue,status,booking_user_name")] eventstable eventstable)
        {
            if (id != eventstable.event_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(eventstable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!eventstableExists(eventstable.event_id))
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
            return View(eventstable);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var eventstable = await _context.eventstables
                .FirstOrDefaultAsync(m => m.event_id == id);
            if (eventstable == null)
            {
                return NotFound();
            }

            return View(eventstable);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var eventstable = await _context.eventstables.FindAsync(id);
            if (eventstable != null)
            {
                _context.eventstables.Remove(eventstable);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool eventstableExists(int id)
        {
            return _context.eventstables.Any(e => e.event_id == id);
        }
    }
}
