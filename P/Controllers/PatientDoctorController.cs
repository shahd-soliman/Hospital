using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P.Models;

namespace P.Controllers
{
    [Authorize(Roles = "Admin,Patient")]
    public class PatientDoctorController : Controller
    {
        HospitalContext context = new HospitalContext();
        public IActionResult Index()
        {
            List<Department> list = context.Departments.Include(d => d.Doctors).ToList();


            return View(list);
        }
    }
}
