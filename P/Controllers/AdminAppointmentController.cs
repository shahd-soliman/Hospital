using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P.IRepo;
using P.Models;

namespace P.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminAppointmentController : Controller
    {
        private readonly HospitalContext context;
        private readonly IAppointment AppointmentRepo;

        public AdminAppointmentController(HospitalContext context,IAppointment AppointmentRepo)
        {
            this.context = context;
            this.AppointmentRepo = AppointmentRepo;
        }

        public IActionResult AppView()
        {
            List<Appointment> app = AppointmentRepo.GetAll();

            return View(app);
        }
        public IActionResult Add()
        {
            ViewData["deptlist"] = context.Departments.ToList();
            ViewData["doclist"] = context.Doctors.ToList();
            return View();
        }
        public IActionResult AppAdd(Appointment app)
        {
            if (app != null)
            {
                AppointmentRepo.Insert(app);
                return RedirectToAction("AppView");
            }

            ViewData["deptlist"] = context.Departments.ToList();
            ViewData["doclist"] = context.Doctors.ToList();
            return View("Add");
        }

        public IActionResult Edit(int id)
        {
            Appointment app = AppointmentRepo.GetByID(id);

            ViewData["deptlist"] = context.Departments.ToList();
            ViewData["doclist"] = context.Doctors.ToList();
            return View(app);
        }
        public IActionResult AppEdit(int id, Appointment app)
        {
            Appointment oldapp = AppointmentRepo.GetByID(id);

            if (oldapp != null)
            {
                AppointmentRepo.Update(id, app);
                return RedirectToAction("AppView");
            }

            ViewData["deptlist"] = context.Departments.ToList();
            ViewData["doclist"] = context.Doctors.ToList();
            return View("Edit", app);
        }
        public IActionResult Delete(int id)
        {
            AppointmentRepo.Delete(id);
            return RedirectToAction("AppView");
        }
    }
}
