using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BuanaBike.Data;
using BuanaBike.Models;

namespace BuanaBike.Controllers
{
    public class ProductRecordsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductRecordsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductRecords
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.ProductRecords.Include(p => p.Product);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ProductRecords/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRecord = await _context.ProductRecords
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productRecord == null)
            {
                return NotFound();
            }

            return View(productRecord);
        }

        // GET: ProductRecords/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: ProductRecords/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProductId,Quantity,TotalPrice,DateCreated")] ProductRecord productRecord)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productRecord);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productRecord.ProductId);
            return View(productRecord);
        }

        // GET: ProductRecords/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRecord = await _context.ProductRecords.FindAsync(id);
            if (productRecord == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productRecord.ProductId);
            return View(productRecord);
        }

        // POST: ProductRecords/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProductId,Quantity,TotalPrice,DateCreated")] ProductRecord productRecord)
        {
            if (id != productRecord.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productRecord);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductRecordExists(productRecord.Id))
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
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id", productRecord.ProductId);
            return View(productRecord);
        }

        // GET: ProductRecords/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productRecord = await _context.ProductRecords
                .Include(p => p.Product)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productRecord == null)
            {
                return NotFound();
            }

            return View(productRecord);
        }

        // POST: ProductRecords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productRecord = await _context.ProductRecords.FindAsync(id);
            if (productRecord != null)
            {
                _context.ProductRecords.Remove(productRecord);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductRecordExists(int id)
        {
            return _context.ProductRecords.Any(e => e.Id == id);
        }
    }
}
