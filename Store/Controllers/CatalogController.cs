using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Store.DataService;

namespace Store.Controllers
{
    public class CatalogController : Controller
    {
        private DataManager _dataManager;

        public CatalogController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            return View(_dataManager.ProductService.GetProducts());
        }


        //[HttpPost]
        //public async Task<IActionResult> IndexAsync(Guid id)
        //{
        //    var product = await _dataManager.ProductService.GetProductByIdAsync(id);
        //    _dataManager.ShoppingCartService.AddItem(product, 1);
        //    return View();
        //}
    }
}
