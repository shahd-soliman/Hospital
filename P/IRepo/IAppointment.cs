using P.Models;

namespace P.IRepo
{
    public interface IAppointment
    {
        public List<Appointment>GetAll();
        public Appointment GetByID(int id);
        void Insert(Appointment appointment);
        void Update(int id, Appointment appointment);
        void Delete(int id);
    }
}
