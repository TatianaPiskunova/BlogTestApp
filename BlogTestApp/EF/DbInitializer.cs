using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace BlogTestApp
{
    public class DbInitializer
    {
        public static async Task InitializeAsync(ApplicationContext context, UserManager<User> userManager, 
           RoleManager<IdentityRole> roleManager)

        {

            if (!context.Posts.Any())
            {
                var posts = new Post[] {
                    new Post
                    {
                         TitlePost = "Topic 1",
                         TextPost="text for blog 1",
                         UserName="Author 1",
                    },
                    new Post
                    {
                         TitlePost = "Topic 2",
                         TextPost="text for blog 2",
                         UserName="Author 1",
                    },
                     new Post
                     {
                         TitlePost = "Topic 3",
                         TextPost="text for blog 3",
                         UserName="Author 2",
                     }
                    
                };
                context.Posts.AddRange(posts);
                context.SaveChanges();
            }

            if (!context.Comments.Any())
            {
                var comments = new Comment[] {
                new Comment
                {
                   
                    TextComment = "comment 1",
                    DateTime = new DateTime(2020, 01, 31, 19, 30, 00),
                    PostId= 1,
                    UserName="eeee"
            },
                   new Comment
                   {

                      TextComment = "comment 2",
                      DateTime = new DateTime(2021, 04, 15, 13, 30, 00),
                      PostId= 2,
                      UserName="ttttttt"
                   },
                   new Comment
                   {

                      TextComment = "comment 3",
                       DateTime = new DateTime(2020, 02, 02, 12, 00, 00),
                       PostId = 1,
                       UserName="poiuyftdrdszxcv"
                   },
                   new Comment
                   {

                      TextComment = "comment 4",
                       DateTime = new DateTime(2020, 02, 02, 15, 23, 00),
                       PostId = 2,
                       UserName="iouy"
                   }
                   

                };
                context.Comments.AddRange(comments);
                context.SaveChanges();



            }

            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            

            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
             
            }
            
            string adminNik = "Boss";
            string password = "&Aa1234";
            if (await userManager.FindByNameAsync(adminNik) == null)
            {
                User admin = new()
                {
                    UserName = adminNik,
                  
                };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                  
                }

            }

          
           

           

        }
    }
}
