using System.Diagnostics;
using HMS.Abstractions;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IPatientServices _patientServices;
        public HomeController(ILogger<HomeController> logger, IPatientServices patientServices)
        {
            _logger = logger;
            _patientServices = patientServices;
        }

        public IActionResult Index()
        {
            
            return View();
        }

       public IActionResult Contactus()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Aboutme()
        {
            return View();
        }
        /// <summary>
        /// list walaa vieww
        /// </summary>
        /// <returns></returns>
        /// 
        
        
        
        public IActionResult Menu()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }
        
       
    }
}

