using HMS.Models;

namespace HMS.Abstractions
{
    public interface IDepartmentServices
    {
        //  List<Department> GetDepartment(string search);
        Task<List<Department>> GetDepartments();
        Department? EditDepartment(Department department);
        void AddDepartment(Department department);

        void DeleteDepartment(Department department);

        void DeleteDepartment(Guid Id);

        Department? GetDepartmentById(Guid Id);
    }
}
