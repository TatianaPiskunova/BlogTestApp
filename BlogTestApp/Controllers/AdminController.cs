using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogTestApp
{
    public class AdminController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
     
        private readonly ApplicationContext db;

        public AdminController(UserManager<User> userManager, ApplicationContext db, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            this.db = db;
            _signInManager = signInManager;
      
        }

        public ActionResult Index()
        {
            List<UserViewModel> users = db.Users
                            .Select(user => new UserViewModel
                            {
                                PhoneNumber = user.PhoneNumber,
                                Email = user.Email,
                                UserName = user.UserName,


                            }).ToList();
            return View(users);


        }


    }
}
