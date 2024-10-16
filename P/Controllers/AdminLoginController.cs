using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using P.Models;
using P.ViewModel;

namespace P.Controllers
{
    public class AdminLoginController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManger;

        public AdminLoginController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManger)
        {
            userManager = _userManager;
            signInManger = _signInManger;
        }
        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(UserLoginViewModel UserVM)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser userModel = await userManager.FindByNameAsync(UserVM.UserName);

                if (userModel != null)
                {
                    bool found = await userManager.CheckPasswordAsync(userModel, UserVM.Password);
                    if (found)
                    {
                        await signInManger.SignInAsync(userModel, UserVM.RememberMe);
                       // await signInManger.RefreshSignInAsync(userModel);

                        var roles = await userManager.GetRolesAsync(userModel);
                     
                        if (roles.Contains("Admin"))
                        {
                            return RedirectToAction("Index");
                        }
                        else if (roles.Contains("Patient"))
                        {
                            return RedirectToAction("Index", "PatientPatient");
                        }
                    }
                }

            }
            else
                ModelState.AddModelError("", "Name or Password are wrong");
            return View(UserVM);
        }
    }
}
