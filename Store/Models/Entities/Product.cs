using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Store.Models.Entities
{
    [Serializable]
    public class Product : EntityBase
    {
        [Display(Name = "Наименование товара")]
        public override string Title { get; set; }

        [Display(Name = "Краткое описание товара")]
        public override string Subtitle { get; set; }

        [Display(Name = "Полное описание товара")]
        public override string Text { get; set; }

        [Display(Name = "Цена товара")]
        public override decimal Price { get; set; }
    }
}
