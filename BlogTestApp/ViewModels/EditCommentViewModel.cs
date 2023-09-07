using System.ComponentModel.DataAnnotations;

namespace BlogTestApp

{
    public class EditCommentViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Ваш комментарий:")]
        public string? TextComment { get; set; }
    
    }
}
