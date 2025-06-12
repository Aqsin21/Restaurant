using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.DataContext.Entities;
using Restaurant.Models;
using System.CodeDom;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;


        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
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
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var existuser=await _userManager.FindByNameAsync(loginViewModel.UserName);
            if (existuser == null)
            {
                ModelState.AddModelError("", "Username or Password is incorrect");
                return View();
            }

            var result =await _signInManager.PasswordSignInAsync(existuser, loginViewModel.Password,loginViewModel.RememberMe,false);
            if (!result.Succeeded)
            {
                
                    ModelState.AddModelError("", "Username or PassWord is incorrect");
                
            }

            return RedirectToAction("Index","Home");
        }
    }
}
