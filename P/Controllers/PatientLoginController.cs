using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace P.Controllers
{
    [Authorize(Roles = "Admin,Patient")]
    public class PatientLoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
