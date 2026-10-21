using cleanArch.Mvc.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace cleanArch.Mvc.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel
            {
                RedirectUrl = returnUrl
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
    .Where(x => x.Value?.Errors.Count > 0)
    .SelectMany(x => x.Value!.Errors.Select(e =>
        $"{x.Key}: {e.ErrorMessage}"))
    .ToList();
                return View(loginViewModel);
            }

            var result = await _signInManager.PasswordSignInAsync(loginViewModel.UserId, loginViewModel.Password, false, lockoutOnFailure: false);
            if (result.Succeeded)
            {
                Console.WriteLine("User logged in successfully.");
                if (!string.IsNullOrEmpty(loginViewModel.RedirectUrl))
                {
                    return Redirect(loginViewModel.RedirectUrl);
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View(loginViewModel);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerViewModel.UserID,
                    NormalizedUserName = registerViewModel.UserID,
                    Email = registerViewModel.Email,
                };
                var result = _userManager.CreateAsync(user, registerViewModel.Password);
                if (!result.Result.Succeeded)
                {
                    foreach (var error in result.Result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(registerViewModel);
                }
                else
                {
                    var resultAdd = _userManager.AddToRolesAsync(user, new[] { "User" });
                    if (!resultAdd.Result.Succeeded)
                    {
                        foreach (var error in resultAdd.Result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return View(registerViewModel);
                    }

                }
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
