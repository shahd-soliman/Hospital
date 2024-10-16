using Hospital.IRepo;
using Hospital.Repo;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P.Models;
using System.ComponentModel.DataAnnotations;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace Hospital.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminRoomController : Controller
    {
        [Required]
        IPatient PatientRepo;
        IRoom RoomRepo;
        private readonly IHostingEnvironment hostingEnvironment;

        public AdminRoomController(IPatient PatientRepo ,IRoom RoomRepo,IHostingEnvironment hostingEnvironment)
        {
            this.PatientRepo = PatientRepo;
            this.RoomRepo = RoomRepo;
            this.hostingEnvironment = hostingEnvironment;
        }
        public IActionResult Index()
        {
            List<Room> Roomlist = RoomRepo.GetAll();
            return View(Roomlist);
        }
        public IActionResult New() {
            return View();
        }
        public IActionResult SaveNew(Room room,IFormFile RoomImgFile) {
            string fileName = string.Empty;
            if (RoomImgFile.FileName != null) {
                string path = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                fileName=RoomImgFile.FileName;
                string fullPath=Path.Combine(path, fileName);
                RoomImgFile.CopyTo(new FileStream(fullPath, FileMode.Create));

            }
            if (room.RoomName != null)
            {
                room.RoomImg = fileName;
                RoomRepo.Insert(room);
                return RedirectToAction("Index");
            }
            return View("New");
        }
        public IActionResult Edit(int id)
        {
            Room doc = RoomRepo.GetByID(id);

            return View(doc);
        }
        public IActionResult RoomEdit(int id, Room room, IFormFile RoomImgFile)
        {
            string fileName = string.Empty;
            if (RoomImgFile.FileName != null)
            {
                string path = Path.Combine(hostingEnvironment.WebRootPath, "uploads");
                fileName = RoomImgFile.FileName;
                string fullPath = Path.Combine(path, fileName);
                RoomImgFile.CopyTo(new FileStream(fullPath, FileMode.Create));

            }
            Room olroom = RoomRepo.GetByID(id);
            if (olroom != null)
            {
                room.RoomImg = fileName;
                RoomRepo.Update(id, room);
                return RedirectToAction("Index");
            }

            return View("Edit", room);
        }
        public IActionResult Delete(int id)
        {
            RoomRepo.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
