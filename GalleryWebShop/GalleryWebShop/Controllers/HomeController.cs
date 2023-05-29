using GalleryWebShop.Data;
using GalleryWebShop.Models;
using Microsoft.AspNetCore.Authorization;
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
            _dbContext= dbContext;
        }

        public IActionResult Index(string? searchQuery, int orderBy = 0)
        {
            // Show all products from database table 
            List<Product> products = _dbContext.Products.ToList();

            // 2. If parameter "serachQuery" not empty and not null,search for the keyword in the title
            if (!String.IsNullOrWhiteSpace(searchQuery))
            {
                //search by title
                products = products.Where(p => p.Title.ToLower().Contains(searchQuery.ToLower())).ToList();
            }

            //0 -default values
            //1 -sorting by title in ascending order
            //2 -sort by title descending  
            //3 -sort by price in ascending order
            //4 -sort by price descending
            switch (orderBy)
            {
                case 1: products = products.OrderBy(p => p.Title).ToList(); break;
                case 2: products = products.OrderByDescending(p => p.Title).ToList(); break;
                case 3: products = products.OrderBy(p => p.Price).ToList(); break;
                case 4: products = products.OrderByDescending(p => p.Price).ToList(); break;
                default: break;
            }

            //returns collection of products
            return View(products);
        }

        public IActionResult ProductByCategory()
         {
            //return View(_dbContext.ProductCategories
            //    .Include(prod => prod.Product)
            //    .Include(cat => cat.Category)
            //    .ToList());

            return View(_dbContext.ProductCategories.ToList());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}