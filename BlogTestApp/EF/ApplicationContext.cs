using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BlogTestApp
{
    public class ApplicationContext : IdentityDbContext<User>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        

        }
        public new DbSet<Post> Posts { get; set; }
        public new DbSet<Comment> Comments { get; set; }
    }
}
