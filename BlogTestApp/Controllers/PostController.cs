using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogTestApp
{
   
    public class PostController : Controller
    {
     
        private readonly UserManager<User> _userManager;

        private readonly ApplicationContext db;

        private readonly IWebHostEnvironment Web;

        public PostController(ApplicationContext context, UserManager<User> userManager, IWebHostEnvironment web)
        {
            _userManager = userManager;
            Web = web;
            db = context;

        }
       
         public IActionResult Index(int? id)
         {
               

                var tmpPost = db.Posts.FirstOrDefault(m => m.Id == id);
                var tmpId=tmpPost?.Id;


               var tmpComments = db.Comments.Where(p => p.PostId == tmpPost.Id).ToList();

           
                var tmpModel = new PostAndCommentsViewModel
                {
                    Id = tmpPost.Id,
                    TitlePost = tmpPost.TitlePost,
                    Comments = tmpComments,
                    UserName = tmpPost.UserName,
                    TextPost = tmpPost.TextPost,
                    Image= tmpPost.Image,
                    

                };
              
                return View(tmpModel);
         }
     

        [HttpGet]
        public IActionResult AddPost()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddPost(AddPostViewModel model)
        {
            if (ModelState.IsValid)
            {
               
                string fileName = UploadeFile(model);

                var post = new Post
                {
                    UserName = model.UserName,
                    TextPost = model.TextPost,
                    TitlePost = model.TitlePost,
                    Image = fileName
                    //Image=updatedImage

                };
               db.Posts.Add(post);
               await db.SaveChangesAsync();
               return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        private string UploadeFile(AddPostViewModel model)
        {

            string fileName = null;
            if (model.Image is not null)
            {
                string uploadDir = Path.Combine(Web.WebRootPath, "images");
                fileName=Guid.NewGuid().ToString()+"-"+model.Image.FileName;
                string filePath=Path.Combine(uploadDir, fileName);
                using(var fileStream=new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return fileName;

        }

        [HttpGet]
        public IActionResult AddComment(int id)
        {
            var vm = new AddCommentViewModel
            {
                Id = id,

            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> AddComment(AddCommentViewModel vm)
        
        {
            if (ModelState.IsValid)
            {
                var comment = new Comment
                {
                    TextComment = vm.TextComment,
                    DateTime = DateTime.Now,
                    PostId = vm.Id,
                    UserName = vm.UserName


                };
                db.Comments.Add(comment);
               await db.SaveChangesAsync();

                return RedirectToAction("Index", "Post", new { id = vm.Id });
            }
            return View(vm);
        }

        [HttpGet]
        public IActionResult EditPost(int id)
        {
            var vm = new EditPostViewModel
            {
                Id = id,
                TextPost = db.Posts.FirstOrDefault(x=>x.Id == id).TextPost,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> EditPost(EditPostViewModel vm)
        {
            if (ModelState.IsValid)
            {
               var tmpPost=db.Posts.FirstOrDefault(db=>db.Id == vm.Id);
               tmpPost.TextPost = vm.TextPost;
                db.Posts.Update(tmpPost);
                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Post", new { id = vm.Id });

            }
            return View(vm);
        }
        [HttpGet]
        public IActionResult EditTitlePost(int id)
        {
            var vm = new EditTitlePostViewModel
            {
                Id = id,
                TextTitlePost = db.Posts.FirstOrDefault(x => x.Id == id).TitlePost,
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> EditTitlePost(EditTitlePostViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var tmpPost = db.Posts.FirstOrDefault(db => db.Id == vm.Id);
                tmpPost.TitlePost = vm.TextTitlePost;
                db.Posts.Update(tmpPost);
                await db.SaveChangesAsync();

                return RedirectToAction("Index", "Post", new { id = vm.Id });

            }
            return View(vm);
        }


    }
}
