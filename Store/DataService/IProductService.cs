using Store.Models.Entities;

namespace Store.DataService
{
    public interface IProductService
    {
        IQueryable<Product> GetProducts();
        Task<Product> GetProductByIdAsync(Guid id);
        void SaveProduct(Product product);
        Task DeleteProductAsync(Guid id);
    }
}
