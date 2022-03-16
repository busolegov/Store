using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Store.DataService;

namespace Store.Controllers
{
    public class CatalogController : Controller
    {
        private ApplicationDbContext _context;

        public CatalogController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            
            var productService = new ProductRepositoryService(_context);
            
            return View(productService.GetProducts());
        }

        [HttpPost]
        public IActionResult Index(Guid id)
        {
            return View();
        }
    }
}
