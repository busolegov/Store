using Store.Models.Entities;

namespace Store.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        public ShoppingCart ShoppingCart { get; set; }
        public string ReturnUrl { get; set; }
    }
}
