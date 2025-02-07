using System.Numerics;
using FluentValidation;
using HMS.Abstractions;
using HMS.Models;
using HMS.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HMS.Controllers
{
    public class DoctorController : Controller
    {
        IDoctorterServices _doctorServices;
       
        private readonly HmsContext _hmsContext;
        public DoctorController(IDoctorterServices doctorService, HmsContext hmsContext)
        {
            _doctorServices = doctorService;
            _hmsContext = hmsContext;
            
        }

        public async Task<ActionResult> Index()
        {
            List<Doctor> doctors = await _doctorServices.GetDoctor();
            return View(doctors);
        }


       
        public IActionResult Create()
        {
            return View();
        }
       
        
        //public IActionResult CreateDoctor(Doctor doctor)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _doctorServices.AddDoctor(doctor);
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(doctor);
        //}
        [HttpPost]
        public IActionResult CreateDoctor(Doctor doctor)
        {
            // Directly add the patient without checking ModelState
            _doctorServices.AddDoctor(doctor);
            return RedirectToAction(nameof(Index));
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                var updatedDoctor = _doctorServices.EditDoctor(doctor);
                if (updatedDoctor == null)
                {
                    return NotFound();
                }
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }


       

        public IActionResult DeleteDoctor(Guid Id)
        {
            Doctor? doctor = _doctorServices.GetDoctorById(Id);
            if (doctor == null)
            {
                return NotFound();
            }
            _doctorServices.DeleteDoctor(doctor);
            return RedirectToAction(nameof(Index));
        }
    

        

        public IActionResult Edit(Guid id)
        {

            var doctor = _doctorServices.GetDoctorById(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        public IActionResult EditDoctor(Doctor doctor)
        {
            Doctor? existDoctor = _doctorServices.EditDoctor(doctor);
            if (existDoctor == null)
            {
                return NotFound();
            }
            

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid Id)
        {
            Doctor? doctor = _doctorServices.GetDoctorById(Id);
            if (doctor == null)
            {
                return NotFound();

            }
            return View("Details", doctor);

        }
        public IActionResult DetailsDoctor(Doctor doctor)
        {

            _doctorServices.AddDoctor(doctor);
            return RedirectToAction(nameof(Index));

        }
    }


}




