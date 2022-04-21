using Microsoft.AspNetCore.Mvc;
using Store.DataService;
using Store.Models.Entities;

namespace Store.Controllers
{
    public class ShoppingCartController : Controller
    {
        private DataManager _dataManager;
        public ShoppingCartController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> AddToCartAsync(Guid id) 
        {
            var product = await _dataManager.ProductService.GetProductByIdAsync(id);

            if (product != null) 
            {
                _dataManager.ShoppingCartService.AddItem(product, 1);
            }
            return RedirectToAction("Index", "Catalog");
        }

    }
}
