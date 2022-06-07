using Microsoft.AspNetCore.Mvc;
using Store.DataService;
using Store.Models.Entities;
using Store.Models.ViewModels;
using System.Text.Json;

namespace Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DataManager _dataManager;
        public ShoppingCartController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public ViewResult Index()
        {
            return View(new ShoppingCartViewModel
            {
                ShoppingCart = HttpContext.Session.GetObj<ShoppingCart>("cart"),
            });
        }

        [HttpPost]
        public IActionResult Index(ShoppingCartViewModel model)
        {
            return View(model.ReturnUrl);
        }

        public ShoppingCart GetCart()
        {
            ShoppingCart cart = HttpContext.Session.GetObj<ShoppingCart>("cart");
            if (cart == null)
            {
                cart = new ShoppingCart();
                HttpContext.Session.SetObj("cart", cart);
            }
            return cart;
        }

        public async Task<ActionResult> AddToCartAsync(Guid id) 
        {
            var product = await _dataManager.ProductService.GetProductByIdAsync(id);

            if (product != null)
            {
                ShoppingCart cart = new ShoppingCart();
                if (HttpContext.Session.Keys.Contains("cart"))
                {
                    cart = HttpContext.Session.GetObj<ShoppingCart>("cart");
                    cart.AddItem(product, 1);
                }
                else
                {
                    cart.AddItem(product, 1);
                }
                HttpContext.Session.SetObj("cart", cart);
            }
            return RedirectToAction("Index", "Catalog");
        }

        public async Task<ActionResult> RemoveFromCartAsync(Guid id) 
        {
            var product = await _dataManager.ProductService.GetProductByIdAsync(id);

            if (product != null)
            {
                ShoppingCart cart = HttpContext.Session.GetObj<ShoppingCart>("cart");
                cart.RemoveItem(product);
                HttpContext.Session.SetObj("cart", cart);
            }
            return RedirectToAction("Index", "ShoppingCart");
        }

        public ActionResult ClearCart() 
        {
            ShoppingCart cart = HttpContext.Session.GetObj<ShoppingCart>("cart");
            cart.RemoveAll();
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Catalog");
        }
    }
}
