using System.ComponentModel.DataAnnotations;

namespace BlogTestApp
{ 
    public class AddPostViewModel
    {
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Название блога:")]
         public string? TitlePost { get; set; }

        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Текст блога:")]
        public string? TextPost { get; set; }
        public string? UserName { get; set; }
        [Display(Name = "Добавить изображение:")]
        public IFormFile? Image { get; set; }


    }
}
