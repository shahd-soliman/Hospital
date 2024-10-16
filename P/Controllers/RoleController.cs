using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using P.Models;
using P.ViewModel;
using Security.ViewModels;

namespace P.Controllers
{
    [Authorize(Roles = ("Admin"))]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole<int>> roleManager;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public RoleController(RoleManager<IdentityRole<int>> roleManager,UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult AddRole()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRole(RoleViewModel roleView)
        {
            if (ModelState.IsValid)
            {
                IdentityRole<int> identityRole = new IdentityRole<int>();
                identityRole.Name = roleView.RoleName;
                IdentityResult result = await roleManager.CreateAsync(identityRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View();
        }

        [HttpGet]
        public IActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddAdmin(UserRegisterViewModel registerView)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser applicationUser = new ApplicationUser();
                applicationUser.UserName = registerView.FirstName;
                applicationUser.FirstName = registerView.FirstName;
                applicationUser.LastName = registerView.LastName;
                applicationUser.PhoneNumber = registerView.phone;
                applicationUser.PasswordHash = registerView.Password;
                IdentityResult result = await userManager.CreateAsync(applicationUser, registerView.Password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(applicationUser, "Admin");
                    await signInManager.SignInAsync(applicationUser, false);
                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("Password", item.Description);
                    }
                }

            }

            return View(registerView);
        }
    }
}
