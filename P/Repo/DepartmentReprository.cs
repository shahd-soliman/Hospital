using P.Models;
using WebApplication2.IRepo;

namespace WebApplication2.Repo
{
    public class DepartmentReprository : IDeparetment
    {
        HospitalContext context;



        public DepartmentReprository(HospitalContext db)
        {
            context = db;
        }


        /*= new ApplicationDbContext(); //db*/

        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }
        public Department GetByID(int id) // 1-Sd-Ahmed
        {
            return context.Departments.FirstOrDefault(e => e.DeptId == id);
        }
        public void Insert(Department department)
        {
            context.Departments.Add(department);
            //save
            context.SaveChanges();

        }
        public void Update(int id, Department newdept)
        {
            // old data = new data 
            //set neew value
            Department oldDept = GetByID(id);

            oldDept.DeptId = newdept.DeptId;
            oldDept.DeptName = newdept.DeptName;
            oldDept.DeptLocation = newdept.DeptLocation;
            oldDept.Description = newdept.Description;
            oldDept.Img= newdept.Img;
            oldDept.Logo= newdept.Logo;
            oldDept.Web_Id = newdept.Web_Id;
            oldDept.Headline = newdept.Headline;
            oldDept.Logo=newdept.Logo;
            context.SaveChanges();
        }
        //Delete
        public void Delete(int id)
        {
            Department dept = GetByID(id); //Ahmed
            context.Departments.Remove(dept);
            context.SaveChanges();
        }
    }
}
