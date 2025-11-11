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
    public class OrdersController : Controller
    {
        private readonly DB1Context _context;

        public OrdersController(DB1Context context)
        {
            _context = context;
        }

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var dB1Context = _context.Orders.Include(o => o.DelieveryMethod).Include(o => o.OrderState).Include(o => o.PaymentMethod).Include(o => o.User);
            return View(await dB1Context.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.DelieveryMethod)
                .Include(o => o.OrderState)
                .Include(o => o.PaymentMethod)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["DelieveryMethodId"] = new SelectList(_context.DelieveryMethods, "DelieveryMethodId", "DisplayName");
            ViewData["OrderStateId"] = new SelectList(_context.OrderStates, "OrderStateId", "DisplayName");
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "DisplayName");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "Name");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserId,Total,CreationDate,OrderStateId,LastEditDate,DelieveryMethodId,PaymentMethodId,IsDeleted")] Order order)
        {
            var lastId = _context.Orders
                     .Select(u => (int?)u.UserId)
                     .Max();
            if (lastId == null) order.OrderId = 0;
            else order.OrderId = lastId.Value + 1;
            order.IsDeleted = false;
            order.CreationDate = DateTime.Now;
            order.LastEditDate = order.CreationDate;
            _context.Add(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            ViewData["DelieveryMethodId"] = new SelectList(_context.DelieveryMethods, "DelieveryMethodId", "DelieveryMethodId", order.DelieveryMethodId);
            ViewData["OrderStateId"] = new SelectList(_context.OrderStates, "OrderStateId", "OrderStateId", order.OrderStateId);
            ViewData["PaymentMethodId"] = new SelectList(_context.PaymentMethods, "PaymentMethodId", "PaymentMethodId", order.PaymentMethodId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", order.UserId);
            return View(order);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,UserId,Total,CreationDate,OrderStateId,LastEditDate,DelieveryMethodId,PaymentMethodId,IsDeleted")] Order order)
        {
            if (id != order.OrderId)
            {
                return NotFound();
            }

            try
            {
                order.LastEditDate = DateTime.Now;
                _context.Update(order);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(order.OrderId))
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

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.DelieveryMethod)
                .Include(o => o.OrderState)
                .Include(o => o.PaymentMethod)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order != null)
            {
                order.IsDeleted = true;
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
