using BlogTestApp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BlogTestApp
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationContext db;


        public HomeController(ILogger<HomeController> logger, ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            _userManager = userManager;
                _signInManager = signInManager;
            db = context;

        }

        public IActionResult Index()
        {
            var tmpList = db.Posts.Select(x => new PostViewModel
            {
                Id = x.Id,
                TitlePost = x.TitlePost,
                AuthorPost = x.UserName
            }).ToList();
                       

            return View(tmpList);
        }

        









        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}