using System.ComponentModel.DataAnnotations;

namespace BlogTestApp
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }

    }
}
