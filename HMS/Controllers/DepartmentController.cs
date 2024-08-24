using System.Security.Cryptography.X509Certificates;
using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DepartmentController : Controller
    {
        private static List<Department> _department = Seed.Department();
        public IActionResult Index()
        {
            return View(_department);
        }



        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateDepartment(Department department)
        {

            _department.Add(department);
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
            Department? department = _department.FirstOrDefault(d => d.Id == Id);
            if (department == null)
            {
                return NotFound();
            }
            _department.Remove(department);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// edit star ho gaya ha 
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult Edit(Guid id)
        {

            var department = _department.FirstOrDefault(d => d.Id == id);
            if (department == null)
            {
                return NotFound();
            }
            return View(department);
        }

        public IActionResult EditDepartment(Department department)
        {
            Department? existDepartment = _department.FirstOrDefault(d => d.Id == department.Id);
            if (existDepartment == null)
            {
                return NotFound();
            }
            existDepartment.Name = department.Name;
            existDepartment.HeaOfDepartment = department.HeaOfDepartment;
            existDepartment.ContactNumbers = department.ContactNumbers;
            existDepartment.Id = department.Id;
            existDepartment.Doctors = department.Doctors;
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid Id)
        {
            Department? department = _department.FirstOrDefault(x => x.Id == Id);
            if (department == null)
            {
                return NotFound();

            }
            return View( "Details",department);

        }
        public IActionResult DetailsDepartment(Department department)
        {

            _department.Add(department);
            return RedirectToAction(nameof(Index));

        }
    }
}
