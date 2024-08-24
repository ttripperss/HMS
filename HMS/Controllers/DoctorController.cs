using System.Numerics;
using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class DoctorController : Controller


    {
        public static List<Doctor> _doctor = Seed.Doctors();

        public IActionResult Index(string searchName)
        {
            // Filter the patients list based on the searchName parameter
            var results = string.IsNullOrWhiteSpace(searchName)
                ? _doctor
                : _doctor.Where(p => p.Name != null && p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();
            //return RedirectToAction("Index", results);
            return View(results);
        }

        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateDoctor(Doctor doctor)
        {

            _doctor.Add(doctor);
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// deparmtnet method ha delte ka
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult DeleteDoctor(Doctor doctor)
        {

            return View(doctor);
        }
        public IActionResult Delete(Guid Id)
        {
            Doctor? doctor = _doctor.FirstOrDefault(d => d.Id == Id);
            if (doctor == null)
            {
                return NotFound();
            }
            _doctor.Remove(doctor);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// edit star ho gaya ha 
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult Edit(Guid id)
        {

            var doctor = _doctor.FirstOrDefault(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        public IActionResult EditDoctor(Doctor doctor)
        {
            Doctor? existDoctor = _doctor.FirstOrDefault(d => d.Id == doctor.Id);
            if (existDoctor == null)
            {
                return NotFound();
            }
            existDoctor.Name = doctor.Name;
            existDoctor.Contactnumber=doctor.Contactnumber;
            existDoctor.Id = doctor.Id;
            existDoctor.DepartmentId=doctor.DepartmentId;
            existDoctor.Email=doctor.Email;
            existDoctor.Experience = doctor.Experience;
            existDoctor.Specialization=doctor.Specialization;

            

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid Id)
        {
            Doctor? doctor = _doctor.FirstOrDefault(x => x.Id == Id);
            if (doctor == null)
            {
                return NotFound();

            }
            return View("Details", doctor);

        }
        public IActionResult DetailsDoctor(Doctor doctor)
        {

            _doctor.Add(doctor);
            return RedirectToAction(nameof(Index));

        }
    }


}
