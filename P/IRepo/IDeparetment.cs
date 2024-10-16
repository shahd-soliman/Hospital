using P.Models;

namespace WebApplication2.IRepo
{
    public interface IDeparetment
    {
        public List<Department> GetAll();

        public Department GetByID(int id); // 1-Sd-Ahmed

        void Insert(Department department);

        void Update(int id, Department newdept);

        void Delete(int id);

    }
}
