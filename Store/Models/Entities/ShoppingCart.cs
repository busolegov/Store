using Store.DataService;


namespace Store.Models.Entities
{
    public class ShoppingCart : IShoppingCartService
    {
        private List<CartItem> Items = new List<CartItem>();

        public void AddItem(Product product, int quantity) 
        {
            CartItem cartItem = Items.Where(x => x.Product.Id == product.Id).FirstOrDefault();

            if (cartItem == null) 
            {
                Items.Add(cartItem = new CartItem
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
            Items.RemoveAll(x => x.Product.Id == product.Id);
        }

        public decimal GetTotalPrice() => Items.Sum(x => x.Product.Price * x.Quantity);


        public void RemoveAll() 
        {
            Items.Clear();
        }

        public IEnumerable<CartItem> CartItems
        {
            get { return Items; }
        }
    }
}
