
using HMS.Abstractions;
using HMS.Models;
using HMS.Services;
using Microsoft.AspNetCore.Mvc;

namespace HMS.Controllers
{
    public class BillingController : Controller
    {
        IBillingServices _billingServices;
        public BillingController(IBillingServices billingServices)
        {
           _billingServices = billingServices;
        }



        public async Task<ActionResult> Index()
        {
            List<Billing> billings = await _billingServices.GetBillings();
            return View(billings);
        }




        public IActionResult Billing()
        {
            return View();
        }
        


        public IActionResult Create()
        {
            return View();
        }
        public IActionResult CreateBilling(Billing billing)
        {

            _billingServices.AddBilling(billing);
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
            Billing? billing = _billingServices.GetBillingById(Id);
            if (billing == null)
            {
                return NotFound();
            }
            _billingServices.DeleteBilling(billing);
            return RedirectToAction(nameof(Index));

        }

        /// <summary>
        /// edit star ho gaya ha 
        /// </summary>
        /// 
        /// <returns></returns>

        public IActionResult Edit(Guid id)
        {

            Billing? billing = _billingServices.GetBillingById(id);
            if (billing == null)
            {
                return NotFound();
            }
            return View(billing);
        }

        public IActionResult EditBilling(Billing billing)
        {
            Billing? existBilling = _billingServices.GetBillingById(billing.Id);
            if (existBilling == null)
            {
                return NotFound();
            }
            _billingServices.DeleteBilling(billing);
            _billingServices.AddBilling(billing);

            return RedirectToAction("Index");
        }

        public IActionResult Details(Guid Id)
        {
            Billing? billing = _billingServices.GetBillingById(Id);
            if (billing == null)
            {
                return NotFound();

            }
            return View("Details", billing);

        }
        public IActionResult DetailsBilling(Billing billing)
        {

            _billingServices.AddBilling(billing);
            return RedirectToAction(nameof(Index));

        }
    }


}

