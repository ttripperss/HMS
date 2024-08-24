using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class BillingController : Controller
    {
        public IActionResult Billing()
        {
            return View();
        }

       
    }
}
