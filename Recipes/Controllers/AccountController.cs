using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models.ViewModels;
using System.Threading.Tasks;
using Recipes.Models;

namespace Recipes.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        public static string login;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        private IUserRepository userRepository;

        public AccountController(UserManager<IdentityUser> userMgr, SignInManager<IdentityUser> signMgr, IUserRepository userRepo)
        {   
            userManager = userMgr;
            signInManager = signMgr;
            userRepository = userRepo;
        }
        
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(new LoginModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(loginModel.Email);
                if (user != null)
                {
                    if ((await signInManager.PasswordSignInAsync(user, loginModel.Password, false, false)).Succeeded)
                    {
                        login = loginModel.Email;
                        return Redirect(loginModel?.ReturnUrl ?? "/Home/Index");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid email or password");
            return View(loginModel);
        }

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            login = null;
            
            return Redirect(returnUrl);
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(AccountViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    var newUser = new User { Email = model.Email };
                    userRepository.SaveUser(newUser);
                    await signInManager.SignInAsync(user, isPersistent: false);
                    
                    return RedirectToAction("Login", "Account");
                }
            }
            ModelState.AddModelError("", "Registration failed");
            return View(model);
        }
    }
}