using System.ComponentModel.DataAnnotations;

namespace College.Models
{
    public class LoginViewModel
    {
        [Display(Name ="Логін")]
        [Required(ErrorMessage ="Введіть логін!")]
        public string? UserName { get; set; }
        [Display(Name = "Пароль")]
        [Required(ErrorMessage = "Введіть пароль!")]
        [UIHint("password")]
        public string? Password { get; set; }
        [Display(Name = "Запам\'ятати мене?")]
        public bool RememberMe { get; set; }
    }
}
