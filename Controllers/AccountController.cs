using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FacturaOnline.Models;
using FacturaOnline.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FacturaOnline.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<Partner> userManager;
        private readonly SignInManager<Partner> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<Partner> userManager,
                                SignInManager<Partner> signInManager,
                                RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View("Error");

            var user = new Partner() {
                UserName = model.Email,
                Email = model.Email
            };
            var result = await userManager.CreateAsync(
                user, model.Password);

            if (!await roleManager.RoleExistsAsync("Partner"))
                await roleManager.CreateAsync(new IdentityRole { Name = "Partner" });

            await userManager.AddToRoleAsync(user, "Partner");

            if (result.Succeeded)
                return View("RegistrationConfirmation");

            foreach (var error in result.Errors)
                ModelState.AddModelError("error", error.Description);
            return View(model);
        }

    }
}
