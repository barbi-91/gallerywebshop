using GalleryWebShop.Common;
using GalleryWebShop.Data;
using GalleryWebShop.Models;
using GalleryWebShop.Services;
using GalleryWebShop.Services.Cart;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebshop.Controllers
{
    public class CartController : Controller
    {
        public readonly ApplicationDbContext _dbContext;
        public CartController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET Cart/Index
        public IActionResult Index()
        {
            try
            {
                ViewBag.ErrorMessage = TempData["ErrorMessage"] as string ?? string.Empty;

                // Check cart from session
                List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(Helper.SessionCartKey);

                // Check error message
                ViewBag.CartErrorMessage = TempData["CartErrorrMessage"] as string ?? string.Empty;

                return View(cart);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(new List<CartItem>());
            }
        }

        //POST: Cart/AddToCart(int productId, decimal quantitiy)
        public IActionResult AddToCart(int productId, decimal quantity)
         {
            try
            {
                //validation if quality is not lower or equal to zero
                if (quantity <= 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                // Check if the product exists
                var findProduct = _dbContext.Products.Find(productId);
                if (findProduct == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                // Verify the session
                List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(Helper.SessionCartKey);

                // If cart is zero than 
                if (cart.Count == 0)
                {
                    // If input value is bigger then stock value end proces like that
                    if (quantity > findProduct.InStock)
                    {
                        TempData["CartErrorMessage"] = $"It is not possible to add a product to the cart! In stock is available {findProduct.InStock}";
                        return RedirectToAction(nameof(Index));
                    }

                    // Continue value of quantity is within stock quantity create new cart item
                    CartItem newItem = new CartItem()
                    {
                        Product = findProduct,
                        Quantity = quantity
                    };
                    // Add item to cart collection
                    cart.Add(newItem);
                    //Update session for cart 
                    HttpContext.Session.SetCartObjectAsJson(Helper.SessionCartKey, cart);
                }
                else
                {
                    //If product is already in cart, create new object class CartItem , else update product in cart
                    var updateOrCreateItem = cart.Find(p => p.Product.Id == productId) ?? new CartItem();

                    // Quantity check for update quantity with stock
                    if (quantity + updateOrCreateItem.Quantity > findProduct.InStock)
                    {
                        TempData["CartErrorMessage"] = $"It is not possible to add a product to the cart! In stock is available {findProduct.InStock} proizvoda {findProduct.Title}";
                        return RedirectToAction(nameof(Index));
                    }
                    // Condition for updating session data
                    if (updateOrCreateItem.Quantity == 0)
                    {
                        updateOrCreateItem.Product = findProduct;
                        updateOrCreateItem.Quantity = quantity;
                        cart.Add(updateOrCreateItem);
                    }
                    else
                    {
                        updateOrCreateItem.Quantity += quantity;
                    }

                    // Update session
                    HttpContext.Session.SetCartObjectAsJson(Helper.SessionCartKey, cart);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
         
        //POST: RemoveFromCart(int productId)
        public IActionResult RemoveFromCart(int productId)
        {
            try
            {
                // Find the cart session and assign it to the cart generic collection variable
                List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(Helper.SessionCartKey);

                // Remove all products that match the Id of the parameter
                cart.RemoveAll(cartItem => cartItem.Product.Id == productId);

                // Update session
                HttpContext.Session.SetCartObjectAsJson(Helper.SessionCartKey, cart);

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction(nameof(Index));
            }
        }
    }
}
