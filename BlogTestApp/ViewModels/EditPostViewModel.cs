using System.ComponentModel.DataAnnotations;

namespace BlogTestApp 
{ 
    public class EditPostViewModel
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Текст блога:")]
        public string? TextPost { get; set; }
    }
}
