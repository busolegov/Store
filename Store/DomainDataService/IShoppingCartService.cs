using Store.Models.Entities;

namespace Store.DataService
{
    public interface IShoppingCartService
    {
        void AddItem(Product product, int quantity);
        void RemoveItem(Product product);
        decimal GetTotalPrice();
        void RemoveAll();
    }
}