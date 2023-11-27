using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OrderManagement.Web.DTOs.IdentityWebDto;

namespace OrderManagement.Web.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        public RegisterController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        //eger databasede kullanici yoksa yeni bir kullanici olusturur, kullanici var ise login sayfasina yonlendirir
        [HttpGet]
        public IActionResult Index()
        {
            var existingUsersCount = _userManager.Users.Count();

            if (existingUsersCount == 0)
            {
                var defaultUser = new AppUser
                {
                    UserName = "DefaultUser",
                    Email = "test@gmail.com"
                };

                var result = _userManager.CreateAsync(defaultUser, "DefaultPassword123.").Result;

                if (result.Succeeded)
                {
                    ViewBag.Message = "Default user has been created.";
                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ViewBag.Message = "Default user creation failed.";
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
            }

            return RedirectToAction("Login");
        }
        [HttpPost]
        public async Task<IActionResult> Index(RegisterWebDto registerWebDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var user = new AppUser
            {
                UserName = registerWebDto.UserName,
            };

            var result = await _userManager.CreateAsync(user, registerWebDto.Password);

            if (result.Succeeded)
            {
                return Content("User has been created successfully.");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
        }

        //Login sayfası
        [HttpGet]  
        public IActionResult Login()
        {
            return View();
        }
        
        //Login sayfası
        [HttpPost]
        public async Task<IActionResult> Login(string email,string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user == null) return View();

            var signInResult = await _signInManager.PasswordSignInAsync(user, password, true, false);
            
            if(!signInResult.Succeeded)
            {
                return View();
            }

            return RedirectToAction("Index","Categories");

        }
        
        //Cıkıs Yapar
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index","Default");
        }
    }
}