using Fitness_Diet_Reviewer.Models;
using Fitness_Diet_Reviewer.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Fitness_Diet_Reviewer.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly ILogger<HomeController> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly DietReviewerContext _context;

        public HomeController(UserManager<ApplicationUser> userManager, ILogger<HomeController> logger, SignInManager<ApplicationUser> signInManager, DietReviewerContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index","Home");
            }
            else
            {
                ViewData["ReturnUrl"] = returnUrl;
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);

                if(result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt");
                }
            }

            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            if (User.Identity.IsAuthenticated)
            {
                await _signInManager.SignOutAsync();
            }

            // Redirect to Home/Index after logout
            return RedirectToAction("Index", "Home");
        }
    

    [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {

                var user = new ApplicationUser
                {
                    UserName = model.Username,
                    EmailConfirmed = true,
                    Gender = model.Gender,
                    Age = model.Age,
                    Height = model.Height,
                    Weight = model.Weight,
                    FirstName = model.FirstName,
                    LastName = model.LastName,

                    // Include other properties as needed
                };

                var result = await _userManager.CreateAsync(user, model.Password);



                if (result.Succeeded)
                {

                    var userToAssign = await _userManager.FindByNameAsync(user.UserName);
                    var newFitnessDiet = new FitnessDiet() { UserId = userToAssign.Id };
                    _context.FitnessDiets.Add(newFitnessDiet);
                    _context.SaveChanges();
                    await _userManager.AddToRoleAsync(userToAssign, "User");
                    TempData["SuccessMessage"] = "Successfully registration!";
                    return RedirectToAction("Register"); // Redirect to home after successful registration
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
