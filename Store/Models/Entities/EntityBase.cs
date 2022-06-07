using System.ComponentModel.DataAnnotations;

namespace Store.Models.Entities
{
    public abstract class EntityBase
    {
        protected EntityBase()
        {
            DateAdded = DateTime.UtcNow;
        }

        [Key]
        [Required]
        public Guid Id { get; set; }

        [Display(Name = "Наименование")]
        public virtual string Title { get; set; }

        [Display(Name = "Краткое описание")]
        public virtual string Subtitle { get; set; }

        [Display(Name = "Полное описание")]
        public virtual string Text { get; set; }

        [DataType(DataType.Currency)]
        [Display(Name = "Цена")]
        public virtual decimal Price { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime DateAdded { get; set; }
    }
}
