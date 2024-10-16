using P.Models;

namespace P.IRepo
{
    public interface IMedicalRecord
    {
        public List <MedicalRecord> GetAll();
        public MedicalRecord GetByID (int id);
        void Insert(MedicalRecord record);
        void Update(int id,MedicalRecord record);
        void Delete (int id);
    }
}
