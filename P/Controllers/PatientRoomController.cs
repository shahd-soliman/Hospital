using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using P.Models;

namespace P.Controllers
{
    [Authorize(Roles = "Admin,Patient")]
    public class PatientRoomController : Controller
    {
        HospitalContext _context = new HospitalContext();

        public IActionResult Index()
        {
            List<Room> roomList = _context.Rooms.ToList();
            return View(roomList);
        }
    }
}
