//using Hospital_medical.Data;
//using Hospital_medical.Models;
//using Microsoft.AspNetCore.Mvc;
//using System.Linq;
//using System.Threading.Tasks;

//public class RegisterController : Controller
//{
//    private readonly AppDbContext _context;

//    public RegisterController(AppDbContext context)
//    {
//        _context = context;
//    }

//    // Registration View
//    [HttpGet]
//    public IActionResult RegisterView()
//    {
//        return View();
//    }

//    // Register Action
//    [HttpPost]
//    public async Task<IActionResult> RegisterView(RegisterViewModel Patients)
//    {
//        if (ModelState.IsValid)
//        {
//            _context.Patients.Add(Patients);
//            await _context.SaveChangesAsync();
//            //return RedirectToAction("Login");
//        }
//        return RedirectToAction("Index", "Home");
//    }

//    //// Login View
//    //[HttpGet]
//    //public IActionResult Login()
//    //{
//    //    return View();
//    //}

//    //// Login Action
//    //[HttpPost]
//    //public IActionResult Login(string username, string password)
//    //{
//    //    var patient = _context.Patients.FirstOrDefault(p => p.Username == username && p.Password == password);

//    //    if (patient != null)
//    //    {
//    //        // Assuming a simple session authentication
//    //        HttpContext.Session.SetString("User", patient.Username);
//    //        return RedirectToAction("Index", "Home");
//    //    }

//    //    ViewBag.Error = "Invalid credentials";
//    //    return View();
//    //}

//    //public IActionResult Logout()
//    //{
//    //    HttpContext.Session.Clear();
//    //    return RedirectToAction("Login");
//    //}
//}
