using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DataContext.Entities;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var user = new AppUser
            {
                UserName = registerViewModel.UserName,
                FullName = registerViewModel.FullName,
                Email = registerViewModel.Email,
                
            };
            var result = await _userManager.CreateAsync(user ,registerViewModel.Password);
            if (!result.Succeeded) 
            {
                foreach (var error in result.Errors) 
                {
                    ModelState.AddModelError("", error.Description); 
                }
                return View();
            }
            return RedirectToAction(nameof(Login));
        }
        public IActionResult Login()
        {
            return View();
        }
    }
}
