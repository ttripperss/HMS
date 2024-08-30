using HMS.Abstractions;
using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;
using NuGet.ContentModel;

namespace HMS.Controllers
{
    public class PatientController : Controller
    {

        IPatientServices _patientServices;
        public PatientController(IPatientServices patientServices)
        {
            _patientServices = patientServices;
        }

       // public static List<Patient> _Patient = Seed.Patient();

        public IActionResult Index(string? searchName)
        {
            // Filter the patients list based on the searchName parameter
            var results = _patientServices.GetPatient(searchName);
            //var results = string.IsNullOrWhiteSpace(searchName)
            //    ? _Patient
            //    : _Patient.Where(p => p.Name != null && p.Name.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

            return View(results);
        }

        


        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreatePatient(Patient patient)
        {

            _patientServices.AddPatient(patient);
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
            Patient? patient = _patientServices.GetPatientById(Id);
            if (patient == null)
            {
                return NotFound();
            }
            _patientServices.DeletePatient(patient);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// edit star ho gaya ha 
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult Edit(Guid Id)
        {
            Patient? patient = _patientServices.GetPatientById(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View(patient);
        }

        [HttpPost]
        public IActionResult EditPatient(Patient patient)
        {
            Patient? existPatient = _patientServices.GetPatientById(patient.Id); ;
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
            Patient? patient = _patientServices.GetPatientById(Id);
            if (patient == null)
            {
                return NotFound();
            }
            return View("Details", patient);
        }




    }
}


/// 



