using System.ComponentModel.DataAnnotations;

namespace Store.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Необходимо ввести логин!")]
        [Display(Name = "Логин")]
        public string Login { get; set; }

        [Required(ErrorMessage ="Необходимо ввести пароль!")]
        [UIHint("password")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }
    }
}
