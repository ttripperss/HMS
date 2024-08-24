using HMS.Data;
using HMS.Models;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class BillingController : Controller
    {


        public static List<Billing> _billing = Seed.billings();
        public IActionResult Billing()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(_billing);
        }



        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateBilling(Billing billing)
        {

            _billing.Add(billing);
            return RedirectToAction(nameof(Index));
        }


        /// <summary>
        /// deparmtnet method ha delte ka
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult DeleteBilling(Billing billing)
        {

            return View(billing);
        }
        public IActionResult Delete(Guid Id)
        {
            Billing? billing = _billing.FirstOrDefault(d => d.Id == Id);
            if (billing == null)
            {
                return NotFound();
            }
            _billing.Remove(billing);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// edit star ho gaya ha 
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult Edit(Guid id)
        {

            Billing? billing = _billing.FirstOrDefault(d => d.Id == id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        public IActionResult EditBilling(Billing billing)
        {
            Billing? existBilling = _billing.FirstOrDefault(d => d.Id == billing.Id);
            if (existBilling == null)
            {
                return NotFound();
            }
           _billing.Remove(existBilling);
            _billing.Add(billing);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid Id)
        {
            Billing? billing = _billing.FirstOrDefault(x => x.Id == Id);
            if (billing == null)
            {
                return NotFound();

            }
            return View("Details", billing);

        }
        public IActionResult DetailsBilling(Billing billing)
        {

            _billing.Add(billing);
            return RedirectToAction(nameof(Index));

        }
    }


}

