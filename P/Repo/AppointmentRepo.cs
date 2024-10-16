using P.IRepo;
using P.Models;

namespace P.Repo
{
    public class AppointmentRepo : IAppointment
    {
        private readonly HospitalContext context;

        public AppointmentRepo(HospitalContext context)
        {
            this.context = context;
        }

        public List<Appointment> GetAll()
        {
           return context.Appointments.ToList();
        }

        public Appointment GetByID(int id)
        {
           return context.Appointments.FirstOrDefault(a => a.ID == id);
        }

        public void Insert(Appointment app)
        {
                context.Appointments.Add(app);
                context.SaveChanges();
            
        }

        public void Update(int id, Appointment app)
        {
            Appointment oldapp = GetByID(id);
            
                oldapp.F_Name = app.F_Name;
                oldapp.L_Name = app.L_Name;
                oldapp.Address = app.Address;
                oldapp.DeptId = app.DeptId;
                oldapp.Message = app.Message;
                oldapp.Date = app.Date;
                oldapp.DocId = app.DocId;
                oldapp.Gender = app.Gender;
                oldapp.Phone = app.Phone;
                context.SaveChanges();
            
        }

        public void Delete(int id)
        {
            Appointment app = GetByID(id);
            context.Appointments.Remove(app);
            context.SaveChanges();
        }
    }
}
