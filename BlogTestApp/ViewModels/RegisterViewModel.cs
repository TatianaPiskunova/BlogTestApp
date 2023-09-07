using System.ComponentModel.DataAnnotations;

namespace BlogTestApp
{ 
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Логин")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Номер телефона")]
        public int PhoneNumber { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердите пароль")]
        public string PasswordConfirm { get; set; }

    }
}
