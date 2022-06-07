using Store.Models.Entities;

namespace Store.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
