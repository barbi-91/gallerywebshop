using GalleryWebShop.Areas.Identity.Data;
using GalleryWebShop.Common;
using GalleryWebShop.Data;
using GalleryWebShop.Models;
using GalleryWebShop.Services;
using GalleryWebShop.Services.Cart;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GalleryWebShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userNManager;

        public OrderController(ApplicationDbContext dbContext, UserManager<ApplicationUser> user)
        {
            _dbContext = dbContext;
            _userNManager = user;
        }

        //GET: Order/Checkout
        public IActionResult Checkout()
        {
            try
            {
                //Korak 1: Find session and check if exist product in cart
                List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(Helper.SessionCartKey);
                if (cart.Count <= 0)
                {
                    return RedirectToAction("Index", "Home");
                }

                ViewBag.CheckoutMessages = TempData["CheckoutMessages"] as string ?? string.Empty;

                return View(cart);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }

        //POST: Order/CreateOrder
        [HttpPost]
        public IActionResult CreateOrder(Order newOrder)
        {
            try
            {
                //3. Korak -Pohrana u bazu, cišcenje kosarice, preusmjeravanje, itd...

                List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(Helper.SessionCartKey);
                // Check if cart is empty
                if (cart.Count <= 0)
                {
                    return RedirectToAction("Index", "Home");
                }

                var modelErrors = new List<string>();
                if (ModelState.IsValid)
                {
                    // Pretend to all product have vat included
                    newOrder.Subtotal = 0;
                    newOrder.Tax = 0;
                    newOrder.Total = cart.Sum(item => item.GetTotal());

                    // Get user id
                    newOrder.UserId = _userNManager.GetUserId(User);

                    _dbContext.Orders.Add(newOrder);
                    _dbContext.SaveChanges();
                    foreach (var cartItem in cart)
                    {
                        OrderItem newOrderItem = new OrderItem()
                        {
                            OrderId = newOrder.Id,
                            ProductId = cartItem.Product.Id,
                            Price = cartItem.Product.Price,
                            Quantity = cartItem.Quantity,
                            Total = cartItem.GetTotal()
                        };
                        _dbContext.OrderItems.Add(newOrderItem);
                    }
                    _dbContext.SaveChanges();

                    HttpContext.Session.Remove(Helper.SessionCartKey);

                    TempData["ThankYouMessage"] = "Thank you for ordering";
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If Error occured or model state is invalid
                    foreach (var modelState in ModelState.Values)
                    {
                        foreach (var error in modelState.Errors)
                        {
                            modelErrors.Add(error.ErrorMessage);
                        }
                    }
                }
                TempData["CheckoutMessages"] = String.Join("<br/>", modelErrors);
                return RedirectToAction(nameof(Checkout));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index", "Home");
            }
        }
    } 
}
