using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity;
using System.Security.Claims;
using Hospital.Repo;
using P.Models;
using P.Repo;
using Hospital.IRepo;
using P.IRepo;
using P.ViewModel;

namespace P.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManger;
        private readonly HospitalContext _context;
        private readonly IPatient _patientRepo;
        private readonly IAppointment _appointmentRepo;

        public AccountController(IPatient _patientRepo, IAppointment _appointmentRepo, HospitalContext _context, UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManger)
        {
            this._patientRepo = _patientRepo;
            this._appointmentRepo = _appointmentRepo;
            this._userManager = _userManager;
            this._signInManger = _signInManger;
            this._context = _context;

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();

        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                string UserName = model.FirstName ;
                var user = new ApplicationUser { UserName = UserName, FirstName = model.FirstName, LastName = model.LastName };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Patient");
                    var patient = new Patient
                    {

                        F_Name = model.FirstName,
                        L_Name = model.LastName,
                        Phone = model.phone,

                        Address = model.Address,
                        userId = (user.Id) 

                    };
                    _patientRepo.Insert(patient);
                    await _context.SaveChangesAsync();


                    //await _userManager.UpdateAsync(user);




                    await _signInManger.SignInAsync(user, isPersistent: true);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
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
                ApplicationUser userModel = await _userManager.FindByNameAsync(UserVM.UserName);

                if (userModel != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(userModel, UserVM.Password);
                    if (found)
                    {
                        await _signInManger.SignInAsync(userModel, UserVM.RememberMe);
                        return RedirectToAction("Index", "PatientPatient");
                    }
                }

            }
            else
                ModelState.AddModelError("", "Name or Password are wrong");
            return View(UserVM);
        }


        public async Task<IActionResult> Logout()
        {
            await _signInManger.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
