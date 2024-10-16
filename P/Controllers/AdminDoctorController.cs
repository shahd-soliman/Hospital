using System.Data.Entity;
using Hospital.IRepo;
using Hospital.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P.Models;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace P.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDoctorController : Controller
    {
        private readonly HospitalContext context;
        private readonly IDoctor DoctorRepo;
        private readonly IHostingEnvironment hostingEnvironment;

        public AdminDoctorController(HospitalContext _context,IDoctor DoctorRepo,IHostingEnvironment hostingEnvironment)
        {
            context = _context;
            this.DoctorRepo = DoctorRepo;
            this.hostingEnvironment = hostingEnvironment;
        }


        public IActionResult DocView()
        {
            List<Doctor> doc = DoctorRepo.GetAll();

            return View(doc);
        }
        public IActionResult Add()
        {
            ViewData["deptlist"] = context.Departments.ToList();
            return View();
        }
        public IActionResult DocAdd(Doctor doc,IFormFile ImgNameFile)
        {   string fileName=string.Empty;
            if (ImgNameFile.FileName != null) {
                string path = Path.Combine(hostingEnvironment.WebRootPath,"uploads");
                fileName=ImgNameFile.FileName;
                string fullpath=Path.Combine(path,fileName);
                ImgNameFile.CopyTo(new FileStream(fullpath,FileMode.Create));
            }
            if (doc != null)
            {
                doc.ImgName = fileName;
                DoctorRepo.Insert(doc);
                return RedirectToAction("DocView");
            }

            ViewData["deptlist"] = context.Departments.ToList();
            return View("Add");
        }

        public IActionResult Edit(int id)
        {
            Doctor doc = DoctorRepo.GetByID(id);

            ViewData["deptlist"] = context.Departments.ToList();
            return View(doc);
        }
        public IActionResult DocEdit(int id, Doctor doc,IFormFile ImgNameFile)
        {
            string fileName = string.Empty;
            if (ImgNameFile.FileName != null)
            {
                string path = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                fileName = ImgNameFile.FileName;
                string fullpath = Path.Combine(path, fileName);
                ImgNameFile.CopyTo(new FileStream(fullpath, FileMode.Create));
            }

            Doctor oldoc = DoctorRepo.GetByID(id);
            if (oldoc != null)
            {
                doc.ImgName = fileName;
                DoctorRepo.Update(id,doc);
                context.SaveChanges();
                return RedirectToAction("DocView");
            }

            ViewData["deptlist"] = context.Departments.ToList();
            return View("Edit", doc);
        }
        public IActionResult Delete(int id)
        {
            DoctorRepo.Delete(id);
            return RedirectToAction("DocView");
        }
    }
}
