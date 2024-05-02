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
    public class CategoriesController : Controller
    {
        private readonly CategoriesDbContext _context;

        public CategoriesController(CategoriesDbContext context)
        {
            _context = context;
        }

        // GET: Categories
        public async Task<IActionResult> Index(string searchString = null)
        {
            var events = from e in _context.event_categories
                select e;

            if (!String.IsNullOrEmpty(searchString))
            {
                events = events.Where(s =>
                    s.category.ToLower().Contains(searchString) ||
                    s.description.ToLower().Contains(searchString) || // Assuming start_date is of type DateTime
                    s.price_per_day.ToString().Contains(searchString) ||   // Assuming end_date is of type DateTime
                    s.price_per_hour.ToString().Contains(searchString) ||
                    s.is_active.ToString().Contains(searchString) ||
                    s.max_capacity.ToString().Contains(searchString)
                );
            }
            return View(await events.ToListAsync());
        }

        // GET: Categories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var event_category = await _context.event_categories
                .FirstOrDefaultAsync(m => m.category_id == id);
            if (event_category == null)
            {
                return NotFound();
            }

            return View(event_category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("category_id,category,description,price_per_hour,price_per_day,is_active,max_capacity")] event_category event_category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(event_category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(event_category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var event_category = await _context.event_categories.FindAsync(id);
            if (event_category == null)
            {
                return NotFound();
            }
            return View(event_category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("category_id,category,description,price_per_hour,price_per_day,is_active,max_capacity")] event_category event_category)
        {
            if (id != event_category.category_id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(event_category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!event_categoryExists(event_category.category_id))
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
            return View(event_category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var event_category = await _context.event_categories
                .FirstOrDefaultAsync(m => m.category_id == id);
            if (event_category == null)
            {
                return NotFound();
            }

            return View(event_category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var event_category = await _context.event_categories.FindAsync(id);
            if (event_category != null)
            {
                _context.event_categories.Remove(event_category);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool event_categoryExists(int id)
        {
            return _context.event_categories.Any(e => e.category_id == id);
        }
    }
}
