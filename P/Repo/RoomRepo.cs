using Hospital.IRepo;
using P.Models;

namespace Hospital.Repo
{
    public class RoomRepo : IRoom
    {
        HospitalContext context;
        public RoomRepo(HospitalContext db)
        {
            context = db;
        }
        public List<Room> GetAll()
        {
            return context.Rooms.ToList();
        }
        public Room GetByID(int id)
        {
            return context.Rooms.FirstOrDefault(e => e.RoomId == id);
        }
        public void Insert(Room room)
        {
            context.Rooms.Add(room);
            context.SaveChanges();
        }
        public void Update(int id, Room newRoom)
        {
            Room oldRoom = GetByID(id);
            oldRoom.RoomName = newRoom.RoomName;
            oldRoom.Location = newRoom.Location;
            oldRoom.RoomImg = newRoom.RoomImg;
            context.SaveChanges();
        }
        //Delete
        public void Delete(int id)
        {
            Room room = GetByID(id);
            context.Rooms.Remove(room);
            context.SaveChanges();
        }
    }
}
