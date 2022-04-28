using Microsoft.AspNetCore.Mvc;
using Store.DataService;
using Store.Models.Entities;
using Store.Models.ViewModels;

namespace Store.Components
{
    public class ShoppingCartViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            var cart = new ShoppingCart();
            if (HttpContext.Session.Keys.Contains("cart"))
            {
                cart = HttpContext.Session.GetObj<ShoppingCart>("cart");

            }

            return View("ShoppingCart", cart);
        }
    }
}
