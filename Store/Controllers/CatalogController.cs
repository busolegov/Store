using Microsoft.AspNetCore.Mvc;
using Store.DataService;
using Store.Models.ViewModels;

namespace Store.Controllers
{
    public class CatalogController : Controller
    {
        private DataManager _dataManager;

        public CatalogController(DataManager dataManager)
        {
            _dataManager = dataManager;
        }

        public IActionResult Index(int page = 1)
        {
            int pageSize = 6;

            var products = _dataManager.ProductService.GetProducts();
            var count = products.Count();
            var items = products.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            PageViewModel pageViewModel = new PageViewModel(count, page, pageSize);
            IndexViewModel indexViewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                Products = items,
            };
            return View(indexViewModel);
        }
    }
}
