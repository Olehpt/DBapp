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
    public class SellerAccountsController : Controller
    {
        private readonly DB1Context _context;

        public SellerAccountsController(DB1Context context)
        {
            _context = context;
        }

        // GET: SellerAccounts
        public async Task<IActionResult> Index()
        {
            var dB1Context = _context.SellerAccounts.Include(s => s.Seller).Include(s => s.User);
            return View(await dB1Context.ToListAsync());
        }

        // GET: SellerAccounts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerAccount = await _context.SellerAccounts
                .Include(s => s.Seller)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SellerAccountId == id);
            if (sellerAccount == null)
            {
                return NotFound();
            }

            return View(sellerAccount);
        }

        // GET: SellerAccounts/Create
        public IActionResult Create()
        {
            ViewData["SellerId"] = new SelectList(_context.Sellers, "SellerId", "SellerId");
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return View();
        }

        // POST: SellerAccounts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SellerAccountId,UserId,SellerId")] SellerAccount sellerAccount)
        {
            var lastId = _context.SellerAccounts
                     .Select(u => (int?)u.SellerAccountId)
                     .Max();
            if (lastId == null) sellerAccount.SellerAccountId = 0;
            else sellerAccount.SellerAccountId = lastId.Value + 1;
            _context.Add(sellerAccount);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: SellerAccounts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerAccount = await _context.SellerAccounts.FindAsync(id);
            if (sellerAccount == null)
            {
                return NotFound();
            }
            ViewData["SellerId"] = new SelectList(_context.Sellers, "SellerId", "SellerId", sellerAccount.SellerId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", sellerAccount.UserId);
            return View(sellerAccount);
        }

        // POST: SellerAccounts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SellerAccountId,UserId,SellerId")] SellerAccount sellerAccount)
        {
            if (id != sellerAccount.SellerAccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sellerAccount);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SellerAccountExists(sellerAccount.SellerAccountId))
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
            ViewData["SellerId"] = new SelectList(_context.Sellers, "SellerId", "SellerId", sellerAccount.SellerId);
            ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId", sellerAccount.UserId);
            return View(sellerAccount);
        }

        // GET: SellerAccounts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sellerAccount = await _context.SellerAccounts
                .Include(s => s.Seller)
                .Include(s => s.User)
                .FirstOrDefaultAsync(m => m.SellerAccountId == id);
            if (sellerAccount == null)
            {
                return NotFound();
            }

            return View(sellerAccount);
        }

        // POST: SellerAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sellerAccount = await _context.SellerAccounts.FindAsync(id);
            if (sellerAccount != null)
            {
                _context.SellerAccounts.Remove(sellerAccount);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SellerAccountExists(int id)
        {
            return _context.SellerAccounts.Any(e => e.SellerAccountId == id);
        }
    }
}
