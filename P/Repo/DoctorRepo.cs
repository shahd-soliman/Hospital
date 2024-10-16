using Hospital.IRepo;
using P.Models;

namespace Hospital.Repo
{
    public class DoctorRepo : IDoctor
    {
        HospitalContext context;
        public DoctorRepo(HospitalContext context)
        {
            this.context = context;
        }
        public List<Doctor> GetAll()
        {
            return context.Doctors.ToList();
        }
        public Doctor GetByID(int id)
        {
            return context.Doctors.FirstOrDefault(e => e.DId ==id);
        }
        public void Insert(Doctor doctor) {
            context.Doctors.Add(doctor);
            context.SaveChanges();
        }
        public void Update(int id, Doctor doc) {
            Doctor oldoc = GetByID(id);
            oldoc.F_Name = doc.F_Name;
            oldoc.M_Name = doc.M_Name;
            oldoc.L_Name = doc.L_Name;
            oldoc.Street = doc.Street;
            oldoc.City = doc.City;
            oldoc.Salary = doc.Salary;
            oldoc.Hire_Date = doc.Hire_Date;
            oldoc.Gender = doc.Gender;
            oldoc.Shift_Type = doc.Shift_Type;
            oldoc.DeptId = doc.DeptId;
            oldoc.ImgName = doc.ImgName;
            context.SaveChanges();

        }
        public void Delete(int id)
        {
            Doctor doctor = GetByID(id);
            context.Doctors.Remove(doctor);
            context.SaveChanges();
        }
    }
}
