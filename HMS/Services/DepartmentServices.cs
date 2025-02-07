using HMS.Abstractions; 
using HMS.Models;

namespace HMS.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly HmsContext _hmsContext;
        public DepartmentServices(HmsContext hmsContext)
        {
            _hmsContext = hmsContext;
        }
        public async Task<List<Department>> GetDepartments()
        {
            var department = _hmsContext.Departments.Where( x => x.IsDeleted ==  null || x.IsDeleted ==  true ).ToList();  

            
            return department;
        }

        public List<Department> GetDepartment()
        {
            List<Department> departments = _hmsContext.Departments.ToList();
            return departments;
        }
        //public static List<Department> GetDepartments(string search = null)
        //{

        //    return _departments
        //.Where(p => string.IsNullOrWhiteSpace(search) || (p.Name != null && p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)))
        //.ToList();
        //}

        public void AddDepartment(Department department)
            {
                _hmsContext.Departments.Add(department);
            }



        
        public Department? EditDepartment(Department department)
        {
            Department? existingdepartment = GetDepartmentById(department.Id);
            if (existingdepartment != null)
            {
                existingdepartment.Name = department.Name;
                existingdepartment.HeaOfDepartment = department.HeaOfDepartment;
                existingdepartment.ContactNumbers = department.ContactNumbers;
                //existingdepartment.Doctors = department.Doctors;

                _hmsContext.Departments.Update(existingdepartment);
                _hmsContext.SaveChanges();
                return existingdepartment;
            }
            return null;
        }

        public void RemoveDepartment(Department department)
            {

                _hmsContext.Departments.Remove(department);

            }
        public void DeleteDepartment(Department department)
        {
            department.IsDeleted = false;
            _hmsContext.Departments.Update(department);
            _hmsContext.SaveChanges();

        }

        public void DeleteDepartment(Guid Id)
            {

            Department? department = GetDepartmentById(Id);
            _hmsContext.Departments.Remove(department);
               

            }
            public Department? GetDepartmentById(Guid Id)
            {
                return _hmsContext.Departments.FirstOrDefault(m => m.Id == Id);
            }




        }
    }





