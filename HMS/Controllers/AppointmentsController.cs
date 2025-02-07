
using HMS.Abstractions;
using HMS.Models;
using HMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class AppointmentsController : Controller
    {
        IAppointmentsServices _appointmentsService;
        public AppointmentsController(IAppointmentsServices appointmentService)
        {
            _appointmentsService = appointmentService;
        }
        public async Task<ActionResult> Index()
        {
            List<Appointment> appointments = await _appointmentsService.GetAppointments();
            return View(appointments);
        }

        //public IActionResult Index(string searchName)
        //{
        //    // Filter the patients list based on the searchName parameter
        //    var results = string.IsNullOrWhiteSpace(searchName)
        //        ? _appointments
        //        : _appointments.Where(p => p.Purpose != null && p.Purpose.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

        //    return View(results);
        //}



        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateAppointments(Appointment appointments)
        {

            _appointmentsService.AddAppointments(appointments);
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// deparmtnet method ha delte ka
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult DeleteAppointments(Appointment appointments)
        {

            return View(appointments);
        }
        public IActionResult Delete(Guid Id)
        {
            Appointment? appointments = _appointmentsService.GetAppointmentsById(Id);
            if (appointments == null)
            {
                return NotFound();
            }
            _appointmentsService.DeleteAppointments(appointments);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// edit star ho gaya ha 
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult Edit(Guid id)
        {

            var appointments = _appointmentsService.GetAppointmentsById(id);
            if (appointments == null)
            {
                return NotFound();
            }
            return View(appointments);
        }

        public IActionResult EditAppointment(Appointment appointments)
        {
            Appointment? existAppointments = _appointmentsService.EditAppointment(appointments);
            if (existAppointments == null)
            {
                return NotFound();
            }
            
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid Id)
        {
            Appointment? appointment = _appointmentsService.GetAppointmentsById(Id);
            if (appointment == null)
            {
                return NotFound();

            }
            return View("Details", appointment);

        }
        public IActionResult DetailsAppointments(Appointment appointment)
        {

            _appointmentsService.AddAppointments(appointment);
            return RedirectToAction(nameof(Index));

        }
    }



}

