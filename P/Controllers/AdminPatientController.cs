using Hospital.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P.Models;
using System.ComponentModel.DataAnnotations;

namespace Hospital.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminPatientController : Controller
    {

        IPatient PatientRepo;
        IRoom RoomRepo;
        public AdminPatientController(IPatient PatientRepo, IRoom Room)
        {
            this.PatientRepo = PatientRepo;
            this.RoomRepo = Room;

        }

        public IActionResult New() //insert

        {
            ViewData["RoomList"] = RoomRepo.GetAll();
            return View();
        }

        public IActionResult Index()
        {
            List<Patient> patient = PatientRepo.GetAll();
            return View(patient);
        }


        public IActionResult SaveNew(Patient patient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    PatientRepo.Insert(patient);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }

            ViewData["RoomList"] = RoomRepo.GetAll();
            return View("New");
        }

        public IActionResult Edit(int id)
        {
            Patient newPatient = PatientRepo.GetById(id);
            ViewData["RoomList"] = RoomRepo.GetAll();
            return View(newPatient);
        }


        public IActionResult SaveEdit(int id, Patient newPatient)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Patient oldpatient = PatientRepo.GetById(id);
                    PatientRepo.Update(id, newPatient);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }

            }

            ViewData["RoomList"] = RoomRepo.GetAll();
            return View("Edit", newPatient);
        }
        public IActionResult Remove(int id)
        {
            Patient patient = PatientRepo.GetById(id);

            if (patient == null)
            {
                return NotFound();
            }
            ViewData["RoomList"] = RoomRepo.GetAll();
            return View(patient);

        }
        public IActionResult ApplyRemove(int id)
        {

            try
            {
                PatientRepo.Delete(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "An error occurred while deleting the patient.");
                return RedirectToAction("Remove", new { id });
            }
        }


    }
}