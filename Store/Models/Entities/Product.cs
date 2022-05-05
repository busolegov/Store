using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Entities
{
    [Serializable]
    public class Product : EntityBase
    {
        [Required(ErrorMessage ="Необходимо ввести название товара!")]
        [Display(Name = "Наименование товара")]
        public override string Title { get; set; }

        [Required(ErrorMessage = "Необходимо ввести караткое описание товара!")]
        [Display(Name = "Краткое описание товара")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание товара")]
        public override string Text { get; set; }

        [Required(ErrorMessage = "Необходимо ввести цену товара!")]
        [Display(Name = "Цена товара")]
        public override decimal Price { get; set; }
    }
}
