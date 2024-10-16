
using Microsoft.EntityFrameworkCore;
using P.Models;

namespace Hospital.IRepo
{
    public interface IPatient
    {
        int P_ID { get; set; }
        List<Patient> GetAll();
        Patient GetById(int id);
        void Update(int id, Patient patient);
        public void Insert(Patient patient);
        public void Delete(int id);
    }
}
