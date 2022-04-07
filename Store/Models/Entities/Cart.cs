namespace Store.Models.Entities
{
    public class Cart
    {
        private List<CartItem> Items = new List<CartItem>();

        public void AddItem() 
        {
        
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
    }
}
