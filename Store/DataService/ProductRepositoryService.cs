using Microsoft.EntityFrameworkCore;
using Store.Models.Entities;

namespace Store.DataService
{
    public class ProductRepositoryService : IProductService
    {
        private readonly ApplicationDbContext _context;

        public ProductRepositoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task DeleteProductAsync(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product != null)
            {
                _context.Remove(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Product> GetProductByIdAsync(Guid id)
        {
            return await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
        }

        public IQueryable<Product> GetProducts()
        {
            return _context.Products;
        }

        public void SaveProduct(Product product)
        {
            if (product.Id == default)
            {
                _context.Entry(product).State = EntityState.Added;
            }
            else
            {
                _context.Entry(product).State = EntityState.Modified;
            }
        }
    }
}
