
using P.Models;

namespace Hospital.IRepo
{
    public interface IDoctor
    {
        List<Doctor> GetAll();


        Doctor GetByID(int id);


       void Insert(Doctor doctor);


       void Update(int id, Doctor newdoctor);


        void Delete(int id);
       
}
}
