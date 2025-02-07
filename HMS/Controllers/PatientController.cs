using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using HMS.Abstractions;
using HMS.Models;
using HMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class PatientController : Controller
    {
        private IValidator<Patient> _validator;
        private readonly IPatientServices _patientServices;
        private readonly HmsContext _hmsContext;

        public PatientController(IPatientServices patientServices, HmsContext hmsContext, IValidator<Patient> validator)
        {
            _patientServices = patientServices;
            _hmsContext = hmsContext;
            _validator = validator;
        }

        public async Task<ActionResult> Index()
        {
            List<Patient> patients = await _patientServices.GetPatients();
            return View(patients);
        }

        public IActionResult Create()
        {   
            return View();
        }

        // Update to handle picture upload
        [HttpPost]
        public async Task<IActionResult> CreatePatient(Patient patient, IFormFile ProfilePicture)
        {
            ValidationResult result = _validator.Validate(patient);

            if (!result.IsValid)
            {
                 result.AddToModelState(this.ModelState);
                return View("Create", patient);
            }

            // Handle picture upload if available
            if (ProfilePicture != null)
            {
                var pictureGuid = Guid.NewGuid();
                var pictureName = "pp-" + pictureGuid + Path.GetExtension(ProfilePicture.FileName);

                // Save the picture in the wwwroot/images directory
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureName);
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await ProfilePicture.CopyToAsync(stream);
                }

                // Assign the picture name to the patient model
                patient.ProfilePictureId = pictureName;
            }

            // Save the patient
            _patientServices.AddPatient(patient);
            return RedirectToAction(nameof(Index));
        }

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
        public IActionResult Edit(Patient patient, IFormFile ProfilePictureId)
        {
            // Validate the patient data
            ValidationResult result = _validator.Validate(patient);
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
                return View("Edit", patient);  // Return to the view with validation errors
            }

            // Check if the patient exists
            if (patient != null)
            {
                // Check if a new profile picture was uploaded
                if (ProfilePictureId != null)
                {
                    if (!string.IsNullOrEmpty(patient.ProfilePictureId))
                    {
                        var oldPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", patient.ProfilePictureId);
                    // Remove old picture if it exists
                    if (System.IO.File.Exists(oldPath))
                    {
                        System.IO.File.Delete(oldPath);  // Delete the old picture
                    }
                    }

                    // Save the new picture
                    var pictureName = "pp-" + Guid.NewGuid() + Path.GetExtension(ProfilePictureId.FileName);
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", pictureName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        ProfilePictureId.CopyToAsync(stream);
                    }

                    // Update the patient's ProfilePictureId with the new picture name
                    patient.ProfilePictureId = pictureName;
                }

                // Update the patient details in the database
                _patientServices.EditPatient(patient);  // Assuming this updates the patient
            }

            // Redirect back to the patient list page
            return RedirectToAction("Index");
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
