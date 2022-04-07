using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Store.Models.ViewModels
{
    public class RegisterViewModel : IdentityUser
    {
        [Required]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли должны совпадать!")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        public string PasswordConfirm { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public string Phone { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Дата рождения")]
        public DateOnly BirthDay { get; set; }
    }
}
