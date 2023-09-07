using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogTestApp
{
    public class Post
    {
        public int Id { get; set; }
        public string? TitlePost { get; set; }
        public string? TextPost { get; set; }
        public List<Comment>? Comments { get; set; }
        public string? UserName { get; set; }
        public string? Image { get; set; }


    }
}
