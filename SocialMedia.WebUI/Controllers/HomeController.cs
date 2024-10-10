using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialMedia.Business.Abstrats;
using SocialMedia.Business.Concretes;
using SocialMedia.Entities.Models;
using SocialMedia.WebUI.Models;
using System.Diagnostics;

namespace SocialMedia.WebUI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<CustomIdentityUser> _userManager;
        private readonly IUserService _userService;

        public HomeController(ILogger<HomeController> logger, UserManager<CustomIdentityUser> userManager, IUserService userService)
        {
            _logger = logger;
            _userManager = userManager;
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewBag.User = user;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }


        public IActionResult Notification()
        {
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }

        public IActionResult Messages() { return View(); }
        public IActionResult Friends() { return View(); }
        public IActionResult Events() { return View(); }
        public IActionResult Login() { return View(); }
        public IActionResult Register() { return View(); }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}