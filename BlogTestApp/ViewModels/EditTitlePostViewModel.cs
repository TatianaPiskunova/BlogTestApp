using System.ComponentModel.DataAnnotations;

namespace BlogTestApp
{
    public class EditTitlePostViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название поста:")]
        public string? TextTitlePost{ get; set; }
    }
}
