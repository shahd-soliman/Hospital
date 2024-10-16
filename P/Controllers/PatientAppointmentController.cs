using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using P.Models;


namespace P.Controllers
{
    [Authorize(Roles = "Admin,Patient")]
    public class PatientAppointmentController : Controller
    {
        HospitalContext _context = new HospitalContext();
        private readonly UserManager<ApplicationUser> _userManager;

        public PatientAppointmentController(HospitalContext context, UserManager<ApplicationUser> _userManager)
        {
            _context = context;
            this._userManager = _userManager;
        }

        public Task<ApplicationUser> GetCurrentUserAsync() => _userManager.GetUserAsync(HttpContext.User);
      
      
        // index and Save for add data and save it
        public async Task< IActionResult> Index()
        {
            Appointment appointment = new Appointment();
            var user = await GetCurrentUserAsync();

            var patient = _context.Patients.FirstOrDefault(p => p.userId == user.Id);
            ViewBag.patientId = patient.PId;
            ViewBag.deptlist = _context.Departments.ToList();
            ViewBag.doclist=_context.Doctors.ToList();
            return View(appointment);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> Save(Appointment app)
        {
            if (ModelState.IsValid)
            {
                _context.Appointments.Add(app);
                var user = await GetCurrentUserAsync();

                var patient = _context.Patients.FirstOrDefault(p => p.userId == user.Id);
                ViewBag.patientId = patient?.PId;
                List<Appointment> appointments = _context.Appointments
               .Where(a => a.PatientId == patient.PId)
               .ToList();
                _context.SaveChanges();
                return View("AppView", appointments);
            }
            ViewBag.deptlist = _context.Departments.ToList();
            return View("Index");

        }
        // for view all appointment that paitient wnat it
        public async Task<IActionResult> AppView()
        {
            var user = await GetCurrentUserAsync();

            var patient = _context.Patients.FirstOrDefault(p => p.userId == user.Id);
            ViewBag.patientId = patient?.PId;
            List<Appointment> appointments = _context.Appointments
           .Where(a => a.PatientId == patient.PId)
           .ToList();
            // List<Appointment> appointments = _context.Appointments.ToList();
            ViewBag.deptlist = _context.Departments.ToList();
            ViewBag.doclist = _context.Doctors.ToList();
            return View(appointments);
        }
        // for select doc in view add and edit
        [HttpGet]
        public JsonResult GetDoctorsByDepartment(int departmentId)
        {
            var doclist = _context.Doctors.Where(x => x.DeptId == departmentId).Select(x => new { id = x.DId, name = x.F_Name }).ToList();

            return Json(doclist);
        }
        // edit and appedit for edit data and save it
        public IActionResult Edit(int id)
        {
            Appointment app = _context.Appointments.FirstOrDefault(x => x.ID == id);
            ViewBag.deptlist = _context.Departments.ToList();
            ViewBag.doclist = _context.Doctors.ToList();
            return View(app);
        }
        public IActionResult AppEdit(int id, Appointment app)
        {
            Appointment oldapp = _context.Appointments.FirstOrDefault(x => x.ID == id);
            if (ModelState.IsValid)
            {
                oldapp.F_Name = app.F_Name;
                oldapp.L_Name = app.L_Name;
                oldapp.Message = app.Message;
                oldapp.Date = app.Date;
                oldapp.DeptId = app.DeptId;
                oldapp.DocId = app.DocId;
                oldapp.Address = app.Address;
                oldapp.Age = app.Age;
                oldapp.Phone = app.Phone;
                oldapp.Gender = app.Gender;
                _context.SaveChanges();
                return RedirectToAction("AppView");
            }
            ViewBag.deptlist = _context.Departments.ToList();
            return View("Edit");
        }
        // for delete data
        public IActionResult Delete(int id)
        {
            Appointment app = _context.Appointments.FirstOrDefault(x => x.ID == id);
            _context.Appointments.Remove(app);
            _context.SaveChanges();
            return RedirectToAction("AppView");
        }
    }
}
