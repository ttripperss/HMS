using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace HMS.Controllers
{
    public class PatientController : Controller
    {

        public static List<Patient> _Patient = Seed.Patient();

        public IActionResult Index()
        {
            return View(_Patient);
        }



        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreatePatient(Patient patient)
        {

            _Patient.Add(patient);
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// deparmtnet method ha delte ka
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult DeletePatient(Patient patient)
        {

            return View(patient);
        }
        public IActionResult Delete(Guid Id)
        {
            Patient? patient = _Patient.FirstOrDefault(d => d.Id == Id);
            if (patient == null)
            {
                return NotFound();
            }
            _Patient.Remove(patient);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// edit star ho gaya ha 
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult Edit(Guid Id)
        {
            Patient? patient = _Patient.FirstOrDefault(d => d.Id == Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        public IActionResult EditPatient(Patient patient)
        {
            Patient? existPatient = _Patient.FirstOrDefault(d => d.Id == patient.Id);
            if (existPatient == null)
            {
                return NotFound();
            }
            existPatient.Name = patient.Name;
            existPatient.Age = patient.Age;
            existPatient.Gender = patient.Gender;
            existPatient.ContactNumber = patient.ContactNumber;
            existPatient.Address = patient.Address;

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid Id)
        {
            Patient? patient = _Patient.FirstOrDefault(x => x.Id == Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View("Details", patient);
        }


    }
}


/// 



