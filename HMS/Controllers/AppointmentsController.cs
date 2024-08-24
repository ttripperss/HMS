using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class AppointmentsController : Controller
    {
        private static List<Appointments> _appointments = Seed.Appointments();
        public IActionResult Index(string searchName)
        {
            // Filter the patients list based on the searchName parameter
            var results = string.IsNullOrWhiteSpace(searchName)
                ? _appointments
                : _appointments.Where(p => p.Purpose != null && p.Purpose.Contains(searchName, StringComparison.OrdinalIgnoreCase)).ToList();

            return View(results);
        }



        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateAppointments(Appointments appointments)
        {

            _appointments.Add(appointments);
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// deparmtnet method ha delte ka
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult DeleteAppointments(Appointments appointments)
        {

            return View(appointments);
        }
        public IActionResult Delete(Guid Id)
        {
            Appointments? appointments = _appointments.FirstOrDefault(d => d.Id == Id);
            if (appointments == null)
            {
                return NotFound();
            }
            _appointments.Remove(appointments);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// edit star ho gaya ha 
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult Edit(Guid id)
        {

            var appointments = _appointments.FirstOrDefault(d => d.Id == id);
            if (appointments == null)
            {
                return NotFound();
            }
            return View(appointments);
        }

        public IActionResult EditAppointment(Appointments appointments)
        {
            Appointments? existAppointments = _appointments.FirstOrDefault(d => d.Id == appointments.Id);
            if (existAppointments == null)
            {
                return NotFound();
            }
            _appointments.Remove(existAppointments);
            _appointments.Add(appointments);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(Guid Id)
        {
            Appointments? appointment = _appointments.FirstOrDefault(x => x.Id == Id);
            if (appointment == null)
            {
                return NotFound();

            }
            return View("Details", appointment);

        }
        public IActionResult DetailsAppontments(Appointments appointment)
        {

            _appointments.Add(appointment);
            return RedirectToAction(nameof(Index));

        }
    }



}

