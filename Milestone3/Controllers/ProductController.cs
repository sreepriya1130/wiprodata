using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoleBasedProductMgmt.Data;
using RoleBasedProductMgmt.Models;

namespace RoleBasedProductMgmt.Controllers
{
    [Authorize(Roles = "Admin,Manager")]
    public class ProductController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ProductController(ApplicationDbContext db) => _db = db;

        // Both Admin & Manager can view products
        public async Task<IActionResult> Index()
        {
            var products = await _db.Products.OrderByDescending(p => p.Id).ToListAsync();
            return View(products);
        }

        // Admin-only: Create product
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Create() => View(new Product());

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model)
        {
            if (!ModelState.IsValid) return View(model);

            _db.Products.Add(model);
            await _db.SaveChangesAsync();
            TempData["Message"] = $"Product \"{model.Name}\" has been successfully created!";
            return RedirectToAction(nameof(Index));
        }

        // Admin & Manager: Edit product
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product model)
        {
            if (!ModelState.IsValid) return View(model);

            var product = await _db.Products.FindAsync(model.Id);
            if (product == null) return NotFound();

            product.Name = model.Name;
            product.Price = model.Price;

            await _db.SaveChangesAsync();
            TempData["Message"] = $"Product \"{model.Name}\" has been successfully updated!";
            return RedirectToAction(nameof(Index));
        }

        // Admin-only: Delete product
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _db.Products.FindAsync(id);
            if (product == null) return NotFound();

            _db.Products.Remove(product);
            await _db.SaveChangesAsync();
            TempData["Message"] = $"Product \"{product.Name}\" has been deleted!";
            return RedirectToAction(nameof(Index));
        }
    }
}
