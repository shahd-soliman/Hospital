using Hospital.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P.IRepo;
using P.Models;

namespace HospitalV1.Controllers
{
    [Authorize(Roles ="Admin,Patient")]
    public class PatientPatientController : Controller
    {
        IAppointment _appointment;
        IPatient _patient;
        public PatientPatientController(IAppointment _appointment, IPatient _patient)
        {
            this._appointment = _appointment;
            this._patient = _patient;
        }
        public IActionResult Index()
        {
            var patient = _patient.GetById;
            return View();
        }
        public IActionResult ViewAppointment(int id)
        {
            var appointment = _appointment.GetByID(id);
            var patient = _patient.GetById(id);

            if (appointment == null)
            {
                // Log the issue or handle it accordingly
                return Content("Appointment not found");
            }

            if (patient == null)
            {
                // Log the issue or handle it accordingly
                return Content("Patient not found");
            }

            var newAppointment = new Appointment
            {
                Date = appointment.Date,
                Message = appointment.Message,
                PatientId = patient.PId,
                Address = patient.Address,
                Age = patient.Age,
                Phone = patient.Phone,
            };

            return View(newAppointment);
        }
        [HttpPost]
        public IActionResult EditAppointment(Appointment newappointment, int id)
        {
            if (ModelState.IsValid)
            {
                _appointment.Update( newappointment.ID, newappointment);
                return RedirectToAction("index", "Home");
            }
            else
                return View(newappointment);

        }
        [HttpGet]
        public IActionResult DeleteAppointment(int id)
        {


            try
            {
                _appointment.Delete(id);
                return NotFound(); // Return a 404 if the appointment doesn't exist
            }
            catch
            {
                return View();
            }

            // Return a view to confirm deletion
        }
    }   
    }

