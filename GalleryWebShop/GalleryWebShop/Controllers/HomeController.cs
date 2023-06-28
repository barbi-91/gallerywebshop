using GalleryWebShop.Data;
using GalleryWebShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace GalleryWebShop.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public IActionResult Index(string? searchQuery, int? categoryId, int orderBy = 0)
        {
            try
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? string.Empty;
                List<Product> productsByCategory = new List<Product>();
                List<Product> productsBySearchQuery = new List<Product>();
                List<Product> products = new List<Product>();
                List<Product> productsOrdered = new List<Product>();

                categoryId ??= 0;

                // 1. If param "categoryId" is not 0, filter products by category
                if (categoryId > 0)
                {
                    productsByCategory = _dbContext.Products.ToList();

                    productsByCategory = productsByCategory
                        .Where(p =>
                            _dbContext.ProductCategories
                            .Where(pc => pc.CategoryId == categoryId)
                            .Select(pc => pc.ProductId)
                            .ToList()
                            .Contains(p.Id))
                        .ToList();
                }

                // 2. If parameter "serachQuery" is not empty and not null,search for the keyword in the title
                if (!String.IsNullOrWhiteSpace(searchQuery))
                {
                    productsBySearchQuery = _dbContext.Products.Where(p => p.Title.ToLower().Contains(searchQuery.ToLower())).ToList();
                }

                // 3. If parameter "serachQuery" and "categoryId" both of is selected to search by
                // If both of is selected - increase one by other
                if (categoryId > 0 && !String.IsNullOrWhiteSpace(searchQuery))
                {
                    products = productsByCategory.IntersectBy(productsBySearchQuery.Select(p => p.Id), p => p.Id).ToList();
                }
                // Search by keword without category selected
                else if (categoryId == 0 && String.IsNullOrWhiteSpace(searchQuery))
                {
                    // Show 10 products from database table rendomly
                    products = _dbContext.Products.OrderBy(r => Guid.NewGuid()).Take(10).ToList();
                }
                else
                {
                    //Else if one of this is selected concat full and empty list
                    products = productsByCategory.Concat(productsBySearchQuery).ToList();
                }

                //0 -default values
                //1 -sorting by title in ascending order
                //2 -sort by title descending  
                //3 -sort by price in ascending order
                //4 -sort by price descending
                if (orderBy >= 1 && orderBy <= 4)
                {
                    switch (orderBy)
                    {
                        case 1:
                            productsOrdered = products.OrderBy(p => p.Title).ToList();
                            break;
                        case 2:
                            productsOrdered = products.OrderByDescending(p => p.Title).ToList();
                            break;
                        case 3:
                            productsOrdered = products.OrderBy(p => p.Price).ToList();
                            break;
                        case 4:
                            productsOrdered = products.OrderByDescending(p => p.Price).ToList();
                            break;
                    }
                }
                else
                {
                    productsOrdered = products;
                }

                ViewBag.Categories = _dbContext.Categories.ToList();

                //returns collection of products
                return View(productsOrdered);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<Product>());
            }
        }

        // Using navigation property with method Include to get data from related tables (foreign key)
        public IActionResult ProductByCategory(int catById)
        {
            try
            {
                var title = _dbContext.Categories.Where(c => c.Id == catById).Select(t => t.Title).Single();
                ViewBag.CatTitle = title;
                // Show all products from database table 
                List<ProductCategory> productsByCategory = _dbContext.ProductCategories
                    .Where(p => p.CategoryId == catById)
                    .Include(c => c.Category)
                    .Include(p => p.Product)
                    .ToList();

                return View(productsByCategory);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        public IActionResult Privacy()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        // GET: Home/Details/5
        public async Task<IActionResult> Details(int? itemId)
        {
            try
            {
                if (itemId == null || _dbContext.Products == null)
                {
                    return NotFound();
                }

                var product = await _dbContext.Products
                    .FirstOrDefaultAsync(m => m.Id == itemId);
                if (product == null)
                {
                    return NotFound();
                }

                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}