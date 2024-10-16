using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P.Models;
using WebApplication2.IRepo;

namespace P.Controllers
{
    [Authorize(Roles = "Admin,Patient")]
    public class PatientDepartmentController : Controller
    {
        HospitalContext context = new HospitalContext();
        IDeparetment deptrepo;
        public IActionResult Index()
        {
            List<Department> departmentList = context.Departments.Include(d => d.Doctors).ToList();
            return View(departmentList);
        }

        public IActionResult New()
        {
            // List<Department> departmentList = context.Departments.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult SaveNew(Department deep)
        {

            // deptrepo.Insert(deep);
            context.Departments.Add(deep);
            context.SaveChanges();
            return RedirectToAction("Index");

        }

    }
}
