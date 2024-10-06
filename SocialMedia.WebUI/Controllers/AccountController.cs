using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Business.Abstrats;
using SocialMedia.Entities.Models;
using SocialMedia.WebUI.Models;

namespace SocialMedia.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly RoleManager<CustomIdentityRole> _roleManager;
        private readonly SignInManager<CustomIdentityUser> _signInManager;
        private readonly SocialMediaDBContext _context;

        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager, SocialMediaDBContext context)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    var user = _context.Users.SingleOrDefault(u => u.UserName == model.Username);
                    user.isOnline = true;
                    _context.Users.Update(user);
                    await _context.SaveChangesAsync();
                }
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "Invalid Login");
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = model.Username,
                    Email = model.Email,
                    City=model.City,
                };
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    CustomIdentityRole role = new CustomIdentityRole
                    {
                        Name = "User"
                    };
                    IdentityResult roleResult = await _roleManager.CreateAsync(role);
                    if (!roleResult.Succeeded) { ModelState.AddModelError("", "We couldn't assign you a role!"); }

                }
                await _userManager.AddToRoleAsync(user, "User");
                return RedirectToAction("Login", "Account");
            }
            return View(model);
        }
    }
}
