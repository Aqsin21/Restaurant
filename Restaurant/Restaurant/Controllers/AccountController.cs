using Mailing;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Restaurant.DataContext.Entities;
using Restaurant.Controllers;
using Restaurant.Models;
using Restaurant.Models;
using Restaurant.DataContext.Entities;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMailService _mailService;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IMailService mailService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mailService = mailService;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new AppUser
            {
                UserName = registerViewModel.UserName,
                Email = registerViewModel.Email,
                FullName = registerViewModel.FullName,
            };

            var result = await _userManager.CreateAsync(user, registerViewModel.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                return View();
            }

            var emailConfirmToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            var emailConfirmLink = Url.Action("ConfirmEmail", "Account", new { emailConfirmToken, user.UserName }, Request.Scheme, Request.Host.ToString());

            _mailService.SendMail(new Mail { ToEmail = user.Email, Subject = "Email confirmation", TextBody = emailConfirmLink });


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
                
                    ModelState.AddModelError("", "Username or Password is incorrect");
                
            }

            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.ChangePasswordAsync(user, changePasswordViewModel.CurrentPassword, changePasswordViewModel.NewPassword);
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

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            if (string.IsNullOrEmpty(email))
                return BadRequest();

            var user = await _userManager.FindByEmailAsync(email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email doesnt found");
                return View();
            }

            var resetToken = await _userManager.GeneratePasswordResetTokenAsync(user);

            var resetLink = Url.Action("ResetPassword", "Account", new { resetToken, email }, Request.Scheme, Request.Host.ToString());

            _mailService.SendMail(new Mail { ToEmail = email, Subject = "Reset pas", TextBody = resetLink });

            return View(nameof(EmailSimulyasiya), resetLink);
        }

        public IActionResult EmailSimulyasiya()
        {
            return View();
        }

        public IActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(resetPasswordViewModel);
            }

            var user = await _userManager.FindByEmailAsync(resetPasswordViewModel.Email);

            if (user == null)
                return BadRequest();

            var result = await _userManager.ResetPasswordAsync(user, resetPasswordViewModel.ResetToken, resetPasswordViewModel.NewPassword);

            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

                return View(resetPasswordViewModel);
            }

            return RedirectToAction(nameof(Login));
        }


        public async Task<IActionResult> ConfirmEmail(string emailConfirmToken, string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                return BadRequest();

            var result = await _userManager.ConfirmEmailAsync(user, emailConfirmToken);

            if (!result.Succeeded)
            {
                return BadRequest();
            }

            return RedirectToAction(nameof(Login));
        }
    }
}
