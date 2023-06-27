using GalleryWebShop.Common;
using GalleryWebShop.Data;
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

                //Korak 1: Provjeri kosaricu iz sesije
                List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(Helper.SessionCartKey);

                // KOrak 2: Provjeri errror poruku
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
                //EXTRA VALIDATION
                if (quantity <= 0)
                {
                    return RedirectToAction(nameof(Index));
                }

                // Korak 1: provjeri ako postoji proizvod
                var findProduct = _dbContext.Products.Find(productId);
                if (findProduct == null)
                {
                    return RedirectToAction(nameof(Index));
                }

                // Korak 2: Provjeri sesiju
                // ova metoda vrca ili praznu ili punu kolekciju
                List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(Helper.SessionCartKey);

                // Korak 3: uvjeti za krositinje kosarice
                if (cart.Count == 0)
                {
                    // Sto ako netko zeli vise proizvoda nego sto ih imamo dosutpno?
                    if (quantity > findProduct.InStock)
                    {
                        TempData["CartErrorMessage"] = $"Nije moguce dodati proizvdo u kosaricu! NA ZALIHI je dostupno {findProduct.InStock}";
                        return RedirectToAction(nameof(Index));
                    }

                    // Kreiraj novi objekt klase CartItem i popuni ga s podacima o proioizviodou i kolicini
                    CartItem newItem = new CartItem()
                    {
                        Product = findProduct,
                        Quantity = quantity
                    };
                    // Dodaj stavku u kolekciju kosarice
                    cart.Add(newItem);
                    //Azuriraj sesiju za kosaricu
                    HttpContext.Session.SetCartObjectAsJson(Helper.SessionCartKey, cart);
                }
                else
                {
                    //Ako proizvod nije u kosarici, kreiraj novi objekt klase CartItem , ako je u kosarici onda smao zauriraj kolicinu tog proizvoda
                    var updateOrCreateItem = cart.Find(p => p.Product.Id == productId) ?? new CartItem();

                    //Provjera kolicine
                    //Primjer 1: U kosarici imamo 2 soka od jabuke , a InStock = 5
                    //Primjer 2: U kosarici nemamo soka od jabuke , a InStock = 3
                    if (quantity + updateOrCreateItem.Quantity > findProduct.InStock)
                    {
                        TempData["CartErrorMessage"] = $"Nije moguce dodati odabranu kolicinu proizvoda. Na Zalihi je dostupno: {findProduct.InStock} proizvoda {findProduct.Title}";
                        return RedirectToAction(nameof(Index));
                    }
                    //Uvjet za azuiranje podataka sesije
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

                    //Azuriraj sesiju
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
                //Korak 1: Pronađi sesiju košarice i dodijeli je varijabli generičke kolekcije cart
                List<CartItem> cart = HttpContext.Session.GetCartObjectFromJson(Helper.SessionCartKey);

                //Korak 2: Ukloni sve proizvode koji se podudaraju s Id-em parametra(npr.: metodom RemoveAll())
                cart.RemoveAll(cartItem => cartItem.Product.Id == productId);

                //Korak 3: Ažuriraj sesiju
                HttpContext.Session.SetCartObjectAsJson(Helper.SessionCartKey, cart);

                //Korak 4: Vrati se na stranicu košarice
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
