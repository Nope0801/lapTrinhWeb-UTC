using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Day09Lab_231230949_17_10_2025.Models;

namespace Day09Lab_231230949_17_10_2025.Controllers
{
    public class HvtLoai_San_PhamController : Controller
    {
        private readonly HvtDay09LabCFContext _context;

        public HvtLoai_San_PhamController(HvtDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: HvtLoai_San_Pham
        public async Task<IActionResult> Index()
        {
            return View(await _context.hvtLoai_San_Phams.ToListAsync());
        }

        // GET: HvtLoai_San_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hvtLoai_San_Pham = await _context.hvtLoai_San_Phams
                .FirstOrDefaultAsync(m => m.hvtId == id);
            if (hvtLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(hvtLoai_San_Pham);
        }

        // GET: HvtLoai_San_Pham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HvtLoai_San_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hvtId,hvtMaLoai,hvtTenLoai,hvtTrangThai")] HvtLoai_San_Pham hvtLoai_San_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hvtLoai_San_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hvtLoai_San_Pham);
        }

        // GET: HvtLoai_San_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hvtLoai_San_Pham = await _context.hvtLoai_San_Phams.FindAsync(id);
            if (hvtLoai_San_Pham == null)
            {
                return NotFound();
            }
            return View(hvtLoai_San_Pham);
        }

        // POST: HvtLoai_San_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("hvtId,hvtMaLoai,hvtTenLoai,hvtTrangThai")] HvtLoai_San_Pham hvtLoai_San_Pham)
        {
            if (id != hvtLoai_San_Pham.hvtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hvtLoai_San_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HvtLoai_San_PhamExists(hvtLoai_San_Pham.hvtId))
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
            return View(hvtLoai_San_Pham);
        }

        // GET: HvtLoai_San_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hvtLoai_San_Pham = await _context.hvtLoai_San_Phams
                .FirstOrDefaultAsync(m => m.hvtId == id);
            if (hvtLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(hvtLoai_San_Pham);
        }

        // POST: HvtLoai_San_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var hvtLoai_San_Pham = await _context.hvtLoai_San_Phams.FindAsync(id);
            if (hvtLoai_San_Pham != null)
            {
                _context.hvtLoai_San_Phams.Remove(hvtLoai_San_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HvtLoai_San_PhamExists(long id)
        {
            return _context.hvtLoai_San_Phams.Any(e => e.hvtId == id);
        }
    }
}
