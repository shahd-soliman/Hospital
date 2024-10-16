
using P.Models;

namespace Hospital.IRepo
{
    public interface IRoom
    {
        List<Room> GetAll();
        Room GetByID(int id);
        void Insert(Room room);
        void Update(int id, Room newRoom);
        void Delete(int id);
        
    }
}
