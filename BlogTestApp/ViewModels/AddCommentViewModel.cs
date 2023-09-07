using System.ComponentModel.DataAnnotations;

namespace BlogTestApp
{
    public class AddCommentViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Display(Name = "Ваш комментарий:")]
        public string? TextComment { get; set; }
        public DateTime DateTime { get; set; }
        public int PostId { get; set; }
        public string? UserName { get; set; }
    }
}
