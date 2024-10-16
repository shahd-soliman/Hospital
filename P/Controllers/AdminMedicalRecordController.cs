using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P.IRepo;
using P.Models;

namespace P.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminMedicalRecordController : Controller
    {
        private readonly HospitalContext context;
        private readonly IMedicalRecord MedicalRepo;

        public AdminMedicalRecordController(HospitalContext _context, IMedicalRecord MedicalRepo)
        {
            context = _context;
            this.MedicalRepo = MedicalRepo;
        }

        public IActionResult MedRecView()
        {
            List<MedicalRecord> list = MedicalRepo.GetAll();
            return View(list);
        }
        public IActionResult Add()
        {
            return View();
        }
        public IActionResult MedRecAdd(MedicalRecord newmed)
        {
            if (newmed != null)
            {
                MedicalRepo.Insert(newmed);
            }
            return View("Add");
        }

        public IActionResult Edit(int id)
        {
            MedicalRecord med = MedicalRepo.GetByID(id);
            return View(med);
        }
        public IActionResult MedRecEdit(int id, MedicalRecord newmed)
        {
            MedicalRecord olmed =MedicalRepo.GetByID(id);

            if (olmed != null)
            {
                MedicalRepo.Update(id, newmed);
                return RedirectToAction("MedRecView");
            }

            return View("Edit", newmed);
        }
        public ActionResult Delete(int id) {

            MedicalRepo.Delete(id);
            return RedirectToAction("MedRecView");
        }

    }
}
