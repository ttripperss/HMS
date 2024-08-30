using HMS.Models;

namespace HMS.Abstractions
{
    public interface IDepartmentServices
    {
        List<Department> GetDepartment(string search);
        void AddDepartment(Department department);

        void DeleteDepartment(Department department);

        void DeleteDepartment(Guid Id);

        Patient? GetDepartmentById(Guid Id);
    }
}
