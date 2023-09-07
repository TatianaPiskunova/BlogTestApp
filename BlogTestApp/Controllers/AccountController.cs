using BlogTestApp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BlogTestApp
{
    public class AccountController:Controller
    {
       
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationContext db;


        public AccountController(ILogger<HomeController> logger, ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
           
            _userManager = userManager;
            _signInManager = signInManager;
            db = context;

        }

        [HttpGet]
        public IActionResult Login()
        {
            var vm = new LoginViewModel();
            return View(vm);


        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.UserName);

                if (user != null)
                {
                    var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.Password);

                    if (isPasswordValid)
                    {
                        await _signInManager.SignInAsync(user, false);
                        if (user.UserName == "Boss")
                        {

                            return RedirectToAction("Index", "Admin");
                        }
                        //await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        public async Task<ActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new User
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    PhoneNumber = model.PhoneNumber.ToString(),
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    result = await _userManager.AddToRoleAsync(user, "user");
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }

                }
            }
            return View(model);
        }
        public IActionResult Clear()
        {
            return RedirectToAction("Index", "Home");
        }




    }
}
