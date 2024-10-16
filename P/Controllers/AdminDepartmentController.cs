using Hospital.IRepo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P.Models;
using WebApplication2.IRepo;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Hospital.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminDepartmentController : Controller
    {
        IDeparetment DepartmentRepo;
        private readonly IHostingEnvironment hostingEnvironment;
        IDoctor DoctorRepo;
        public AdminDepartmentController(IDoctor doctorRepo, IDeparetment DepartmentRepo,IHostingEnvironment hostingEnvironment)
        {
            this.DoctorRepo = doctorRepo;
            this.DepartmentRepo = DepartmentRepo;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult New() {
            ViewData["DoctorList"]=DoctorRepo.GetAll();
            return View();
        }

        public IActionResult Index()
        {
            List<Department> department =DepartmentRepo.GetAll();
            return View(department);
        }
        public IActionResult SaveNew(Department department,IFormFile ImgFile)
        {
            if (!ModelState.IsValid)
            {
                try
                {
                    string fileName = string.Empty;
                    if (ImgFile.FileName != null) {
                        string path = Path.Combine(hostingEnvironment.WebRootPath,"uploads");
                        fileName=ImgFile.FileName;
                        string fullpath=Path.Combine(path,fileName);
                        ImgFile.CopyTo(new FileStream(fullpath, FileMode.Create));
                    
                    }
                    if (department != null)
                    {
                        department.Img = fileName;
                        DepartmentRepo.Insert(department);
                        return RedirectToAction("Index");
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);

                }
            }

            ViewData["DoctorList"] = DoctorRepo.GetAll();
            return View("New");
        }
        public IActionResult Edit(int id) {
            Department newdept = DepartmentRepo.GetByID(id);
            ViewData["DoctorList"] = DoctorRepo.GetAll();
            return View(newdept);

        }
        public IActionResult SaveEdit(int id, Department department , IFormFile ImgFile) {
            if (ModelState.IsValid)
            {
                try
                {
                    string fileName = string.Empty;
                    if (ImgFile.FileName != null)
                    {
                        string path = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                        fileName = ImgFile.FileName;
                        string fullpath = Path.Combine(path, fileName);
                        ImgFile.CopyTo(new FileStream(fullpath, FileMode.Create));

                    }
                    Department oldpept = DepartmentRepo.GetByID(id);
                    department.Img = fileName;
                    DepartmentRepo.Update(id, department);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
                ViewData["DoctorList"] = DoctorRepo.GetAll();
                return View("Edit",department);
        }
        public IActionResult Remove(int id)
        {
            Department department = DepartmentRepo.GetByID(id);
            if (department == null) {
                return NotFound();
            }
            ViewData["DoctorList"] = DoctorRepo.GetAll();
            return View(department);

        }
        public IActionResult ApplyRemove(int id)
        {
            try
            {
                DepartmentRepo.Delete(id);
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
