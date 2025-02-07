using System.Security.Cryptography.X509Certificates;
using HMS.Abstractions;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DepartmentController : Controller
    {

        //public IActionResult Index(string searchName)
        //{
        //    // Filter the patients list based on the searchName parameter
        //    var results = string.IsNullOrWhiteSpace(searchName)
        //        ? _department
        //        : _department.Where(p => p.Name != null && p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

        //    return View(results);
        //}
        IDepartmentServices _departmentService;
        public DepartmentController(IDepartmentServices departmentService)
        {
            _departmentService = departmentService;
        }

        public async Task<ActionResult> Index()
        {
            List<Department> departments = await _departmentService.GetDepartments();
            return View(departments);
        }



        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateDepartment(Department department)
        {

             _departmentService.AddDepartment(department);
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// deparmtnet method ha delte ka
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult DeleteDepartment(Department department)
        {

            return View(department);
        }
        public IActionResult Delete(Guid Id)
        {
            Department? department = _departmentService.GetDepartmentById(Id);
            if (department == null)
            {
                return NotFound();
            }
            _departmentService.DeleteDepartment(department);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// edit star ho gaya ha 
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult Edit(Guid id)
        {

            var department = _departmentService.GetDepartmentById(id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        public IActionResult EditDepartment(Department department)
        {
            var existDepartment = _departmentService.EditDepartment(department);
            
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid Id)
        {
            Department? department = _departmentService.GetDepartmentById(Id);
            if (department == null)
            {
                return NotFound();

            }
            return View( "Details",department);

        }
       
    }
}
