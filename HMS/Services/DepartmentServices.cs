using HMS.Abstractions;
using HMS.Data;
using HMS.Models;

namespace HMS.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        public static List<Department> _departments = Seed.Department();

        public static List<Department> GetDepartments(string search = null)
        {

            return _departments
        .Where(p => string.IsNullOrWhiteSpace(search) || (p.Name != null && p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)))
        .ToList();
        }

        public void AddDeapaertment(Department department)
        {
            _departments.Add(department);
        }

        public void AddDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void DeleteDepartment(Department department)
        {
            _departments.Remove(department);

        }

        public void DeleteDepartment(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<Department> GetDepartment(string search)
        {
            throw new NotImplementedException();
        }

        public Patient? GetDepartmentById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
