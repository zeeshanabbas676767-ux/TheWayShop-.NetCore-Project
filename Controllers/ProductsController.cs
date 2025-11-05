using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewCoreProject.Data;
using NewCoreProject.Models;

namespace NewCoreProject.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductsController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Products.Include(p => p.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Product_Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            ViewData["Category_Fid"] = new SelectList(_context.Categories, "Category_Id", "Category_Name");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(IFormFile Pro_Pic, [Bind("Product_Id,Product_Name,Product_Description,Product_PurchasePrice,Product_SalePrice,Product_Picture,Category_Fid")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (Pro_Pic != null)
                {
                    var filePath = Path.Combine(_env.WebRootPath, "images", Pro_Pic.FileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await Pro_Pic.CopyToAsync(stream);
                    }
                    product.Product_Picture = "/images/" + Pro_Pic.FileName;
                }
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Category_Fid"] = new SelectList(_context.Categories, "Category_Id", "Category_Name", product.Category_Fid);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["Category_Fid"] = new SelectList(_context.Categories, "Category_Id", "Category_Name", product.Category_Fid);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Product_Id,Product_Name,Product_Description,Product_PurchasePrice,Product_SalePrice,Product_Picture,Category_Fid")] Product product, IFormFile? Pro_Pic)
        {
            if (id != product.Product_Id)
            {
                return NotFound();
            }
            var existingProduct = await _context.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Product_Id == id);
            if (existingProduct == null)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    // If new image uploaded
                    if (Pro_Pic != null)
                    {
                        // delete old image
                        if (!string.IsNullOrEmpty(existingProduct.Product_Picture))
                        {
                            var oldPath = Path.Combine(_env.WebRootPath, existingProduct.Product_Picture.TrimStart('/'));
                            if (System.IO.File.Exists(oldPath))
                                System.IO.File.Delete(oldPath);
                        }

                        string fileName = $"{Guid.NewGuid()}{Path.GetExtension(Pro_Pic.FileName)}";
                        string path = Path.Combine(_env.WebRootPath, "images", fileName);

                        using (var stream = new FileStream(path, FileMode.Create))
                        {
                            await Pro_Pic.CopyToAsync(stream);
                        }

                        product.Product_Picture = "/images/" + fileName;
                    }
                    else
                    {
                        // Keep old image
                        product.Product_Picture = existingProduct.Product_Picture;
                    }

                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Product_Id))
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
            ViewData["Category_Fid"] = new SelectList(_context.Categories, "Category_Id", "Category_Name", product.Category_Fid);
            return View(product);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Product_Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.Product_Id == id);
        }
    }
}
