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
    public class HvtSan_PhamController : Controller
    {
        private readonly HvtDay09LabCFContext _context;

        public HvtSan_PhamController(HvtDay09LabCFContext context)
        {
            _context = context;
        }

        // GET: HvtSan_Pham
        public async Task<IActionResult> Index()
        {
            return View(await _context.hvtSan_Phams.ToListAsync());
        }

        // GET: HvtSan_Pham/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hvtSan_Pham = await _context.hvtSan_Phams
                .FirstOrDefaultAsync(m => m.hvtId == id);
            if (hvtSan_Pham == null)
            {
                return NotFound();
            }

            return View(hvtSan_Pham);
        }

        // GET: HvtSan_Pham/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: HvtSan_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("hvtId,hvtMaSanPham,hvtTenSanPham,hvtHinhAnh,hvtSoLuong,hvtDonGia,hvtLoaiSanPhamId")] HvtSan_Pham hvtSan_Pham)
        {
            var loaiSanPham = await _context.hvtLoai_San_Phams
            .FirstOrDefaultAsync(l => l.hvtMaLoai == hvtSan_Pham.hvtLoaiSanPhamId.ToString());

            if (loaiSanPham == null)
            {
                // Thêm lỗi vào ModelState nếu không tìm thấy loại sản phẩm
                ModelState.AddModelError("hvtLoaiSanPhamId", "Không tìm thấy loại sản phẩm phù hợp.");
                return View(hvtSan_Pham);
            }
            hvtSan_Pham.hvtLoai_San_Pham = loaiSanPham;
            if (!ModelState.IsValid)
            {
                foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
                {
                    Console.WriteLine($"Error: {error.ErrorMessage}");
                }
            }
            if (ModelState.IsValid)
            {

                _context.Add(hvtSan_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(hvtSan_Pham);
        }

        // GET: HvtSan_Pham/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hvtSan_Pham = await _context.hvtSan_Phams.FindAsync(id);
            if (hvtSan_Pham == null)
            {
                return NotFound();
            }
            return View(hvtSan_Pham);
        }

        // POST: HvtSan_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("hvtId,hvtMaSanPham,hvtTenSanPham,hvtHinhAnh,hvtSoLuong,hvtDonGia,hvtLoaiSanPhamId")] HvtSan_Pham hvtSan_Pham)
        {
            if (id != hvtSan_Pham.hvtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(hvtSan_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HvtSan_PhamExists(hvtSan_Pham.hvtId))
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
            return View(hvtSan_Pham);
        }

        // GET: HvtSan_Pham/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hvtSan_Pham = await _context.hvtSan_Phams
                .FirstOrDefaultAsync(m => m.hvtId == id);
            if (hvtSan_Pham == null)
            {
                return NotFound();
            }

            return View(hvtSan_Pham);
        }

        // POST: HvtSan_Pham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var hvtSan_Pham = await _context.hvtSan_Phams.FindAsync(id);
            if (hvtSan_Pham != null)
            {
                _context.hvtSan_Phams.Remove(hvtSan_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HvtSan_PhamExists(long id)
        {
            return _context.hvtSan_Phams.Any(e => e.hvtId == id);
        }
    }
}
