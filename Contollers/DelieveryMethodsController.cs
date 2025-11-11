using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DBapp.Data;
using DBapp.Models;

namespace DBapp.Contollers
{
    public class DelieveryMethodsController : Controller
    {
        private readonly DB1Context _context;

        public DelieveryMethodsController(DB1Context context)
        {
            _context = context;
        }

        // GET: DelieveryMethods
        public async Task<IActionResult> Index()
        {
            return View(await _context.DelieveryMethods.ToListAsync());
        }

        // GET: DelieveryMethods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delieveryMethod = await _context.DelieveryMethods
                .FirstOrDefaultAsync(m => m.DelieveryMethodId == id);
            if (delieveryMethod == null)
            {
                return NotFound();
            }

            return View(delieveryMethod);
        }

        // GET: DelieveryMethods/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DelieveryMethods/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DelieveryMethodId,DisplayName")] DelieveryMethod delieveryMethod)
        {
            var lastId = _context.DelieveryMethods
                    .Select(u => (int?)u.DelieveryMethodId)
                    .Max();
            if (lastId == null) delieveryMethod.DelieveryMethodId = 0;
            else delieveryMethod.DelieveryMethodId = lastId.Value + 1;
            _context.Add(delieveryMethod);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: DelieveryMethods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delieveryMethod = await _context.DelieveryMethods.FindAsync(id);
            if (delieveryMethod == null)
            {
                return NotFound();
            }
            return View(delieveryMethod);
        }

        // POST: DelieveryMethods/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DelieveryMethodId,DisplayName")] DelieveryMethod delieveryMethod)
        {
            if (id != delieveryMethod.DelieveryMethodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(delieveryMethod);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DelieveryMethodExists(delieveryMethod.DelieveryMethodId))
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
            return View(delieveryMethod);
        }

        // GET: DelieveryMethods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var delieveryMethod = await _context.DelieveryMethods
                .FirstOrDefaultAsync(m => m.DelieveryMethodId == id);
            if (delieveryMethod == null)
            {
                return NotFound();
            }

            return View(delieveryMethod);
        }

        // POST: DelieveryMethods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var delieveryMethod = await _context.DelieveryMethods.FindAsync(id);
            if (delieveryMethod != null)
            {
                _context.DelieveryMethods.Remove(delieveryMethod);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DelieveryMethodExists(int id)
        {
            return _context.DelieveryMethods.Any(e => e.DelieveryMethodId == id);
        }
    }
}
