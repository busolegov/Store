using Store.DataService;
using System.Web;

namespace Store.Models.Entities
{
    public class ShoppingCart : IShoppingCartService
    {
        private List<CartItem> ItemsCollection = new List<CartItem>();

        public void AddItem(Product product, int quantity) 
        {
            CartItem cartItem = ItemsCollection.Where(x => x.Product.Id == product.Id).FirstOrDefault();

            if (cartItem == null) 
            {
                ItemsCollection.Add(cartItem = new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                cartItem.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product) 
        {
            CartItem cartItem = ItemsCollection.Where(x => x.Product.Id == product.Id).FirstOrDefault();
            if (cartItem != null) 
            {
                cartItem.Quantity--;
                if (cartItem.Quantity==0)
                {
                    ItemsCollection.Remove(cartItem);
                }
            }
        }

        public decimal GetTotalPrice() => ItemsCollection.Sum(x => x.Product.Price * x.Quantity);


        public void RemoveAll() 
        {
            ItemsCollection.Clear();
        }

        public IEnumerable<CartItem> CartItems
        {
            get { return ItemsCollection; }
        }

        public int GetCount() 
        {
            int count = 0;
            foreach (var item in ItemsCollection)
            {
                count += item.Quantity;
            }
            return count;
        }
    }
}
