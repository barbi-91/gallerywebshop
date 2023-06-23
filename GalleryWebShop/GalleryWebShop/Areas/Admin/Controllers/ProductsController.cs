using GalleryWebShop.Data;
using GalleryWebShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GalleryWebShop.Areas.Admin.Controllers
{

    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            return _context.Products != null ?
                        View(await _context.Products.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Products' is null.");
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? "";
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Id,Sku,Title,Size,Description,InStock,Price,Image")] Product product,
            int[] categoryIds,
            IFormFile Image)
        {
            // Check if parametar categoryIds is empty or null
            if (categoryIds.Length == 0 || categoryIds == null)
            {
                TempData["ErrorMessage"] = "Please select at least one category!";
                return RedirectToAction(nameof(Create));
            }

            if (ModelState.IsValid)
            {
                try
                {
                    // Store image file in folder using path
                    var getFimeExtension = Path.GetExtension(Image.FileName);
                    var imageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_" +
                           Image.FileName.ToLower().Replace(" ", "_");

                    var saveImagePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/images/products",
                        imageName
                        );
                    //Creating Directory using path
                    Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));
                    using (var stream = new FileStream(saveImagePath, FileMode.Create))
                    {
                        Image.CopyTo(stream);
                    }
                    // Store only the file name in the table column
                    product.Image = imageName;
                }
                catch (Exception ex)
                {

                    TempData["ErrorMessage"] = ex.Message;
                    return RedirectToAction(nameof(Create));
                }

                _context.Add(product);
                await _context.SaveChangesAsync();

                // Match the productId with the items of the categoryIds array and store everything in the ProductCategories table
                foreach (var categoryId in categoryIds)
                {
                    ProductCategory productCategory = new ProductCategory();
                    productCategory.CategoryId = categoryId;
                    productCategory.ProductId = product.Id;

                    _context.ProductCategories.Add(productCategory);
                }
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }


            // Get the Ids of the categories that the product is associated with in the ProdcutCategories table
            ViewBag.ProductCategories = _context.ProductCategories.Where(
                p => p.ProductId == product.Id
                ).Select(c => c.CategoryId).ToList();

            ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? "";
            return View(product);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Sku,Title,Size,Description,InStock,Price,Image")] Product product,
            int[] categoryIds,
            IFormFile? newImage
            )
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            // Check if parametar categoryIds is empty or null
            if (categoryIds.Length == 0 || categoryIds == null)
            {
                TempData["ErrorMessage"] = "Please select at least one category!";
                return RedirectToAction(nameof(Edit), new { id = id });
            }

            // Match the productId with the items of the categoryIds array and store everything in the ProductCategories table


            if (ModelState.IsValid)
            {
                try
                {
                    if (newImage != null)
                    {
                        var newImageName = DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + "_" +
                            newImage.FileName.ToLower().Replace(" ", "_");
                        var saveImagePath = Path.Combine(
                            Directory.GetCurrentDirectory(),
                            "wwwroot/images/products",
                            newImageName
                            );

                        Directory.CreateDirectory(Path.GetDirectoryName(saveImagePath));
                        using (var stream = new FileStream(saveImagePath, FileMode.Create))
                        {
                            newImage.CopyTo(stream);
                        }
                        product.Image = newImageName;

                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                    //Update product category in table ProductCategories
                    _context.ProductCategories.RemoveRange(_context.ProductCategories.Where(p => p.ProductId == id));
                    _context.SaveChanges();

                    foreach (var category in categoryIds)
                    {
                        ProductCategory productCategory = new ProductCategory();
                        productCategory.CategoryId = category;
                        productCategory.ProductId = product.Id;

                        _context.ProductCategories.Add(productCategory);
                    }
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Products == null)
            {
                return NotFound();
            }

            var product = await _context.Products
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Products'  is null.");
            }
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                if (!String.IsNullOrWhiteSpace(product.Image))
                {
                     var deleteImageFromPath = Path.Combine(Directory.GetCurrentDirectory(),
                        "wwwroot/images/products",
                        product.Image
                    );
                    if (System.IO.File.Exists(deleteImageFromPath))
                    {
                        System.IO.File.Delete(deleteImageFromPath);
                    }
                }
                _context.Products.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
