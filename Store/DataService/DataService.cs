namespace Store.DataService
{
    public class DataService
    {
        public IProductService ProductService { get; set; }

        public DataService(IProductService productService)
        {
            ProductService = productService;
        }

    }
}
