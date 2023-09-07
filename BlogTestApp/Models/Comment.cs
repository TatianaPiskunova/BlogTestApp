using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlogTestApp
{
    public class Comment
    {
        public int Id { get; set; }
        public string? TextComment { get; set; }
        public DateTime DateTime { get; set; }
        public int PostId { get; set; }
        public string? UserName { get; set; }
    }
}
