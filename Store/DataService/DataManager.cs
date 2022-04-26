namespace Store.DataService
{
    public class DataManager
    {
        public IProductService ProductService { get; set; }
        public IShoppingCartService ShoppingCartService { get; set; }

        public DataManager(IProductService productService, IShoppingCartService shoppingCartService)
        {
            ProductService = productService;
            ShoppingCartService = shoppingCartService;
        }
    }
}
