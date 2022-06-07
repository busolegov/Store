using Store.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.ViewModels
{
    public class ShoppingCartViewModel
    {
        [Required]
        public ShoppingCart ShoppingCart { get; set; }
        
        [Required]
        public string ReturnUrl { get; set; }
    }
}
