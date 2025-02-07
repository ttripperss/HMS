using HMS.Abstractions;
using HMS.Models;

namespace HMS.Services
{
    public class BillingServices : IBillingServices
    {

        private readonly HmsContext _hmsContext;
        public BillingServices(HmsContext hmsContext)
        {
            _hmsContext = hmsContext;

        }


        public async Task<List<Billing>> GetBillings()
        {
            var billing = _hmsContext.Billings.ToList();

            return billing;
        }

        //public List<Billing> GetBillings()
        //{
        //    List<Billing> billing= _hmsContext.Billings.ToList();
        //    return billing;
        //}

        //public static List<Billing> GetBillingByID(Guid? search = null)
        //{
        //    var results = search == null
        //        ? _billing
        //        : _billing.Where(p => p.Id == search.Value).ToList();
        //    return results;
        //}

        public void AddBilling(Billing billing) { 
        
        _hmsContext.Billings.Add(billing);
         
        }
        public void RemoveBilling(Billing billing) { 
        
         _hmsContext.Billings.Remove(billing);
                   
       }
        //public void DeleteBilling(Guid Id)
        //{

        //    if ((Billing?)GetBillingByID(Id) != null)
        //    {
        //        DeleteBilling((Billing?)GetBillingByID(Id));
        //    }
        //    else
        //    {
        //        // Optionally, handle the case where the billing record is not found
        //        // For example, log an error, throw an exception, etc.
        //        Console.WriteLine("Billing record not found.");
        //    }
        //}
        public void DeleteBilling(Guid Id)
        {
            Billing? billing  = GetBillingById(Id);
             _hmsContext.Billings.Remove(billing);
            
        }


        public void DeleteBilling(Billing billing)
        {
            _hmsContext.Billings.Remove(billing);

        }
        public Billing? GetBillingById(Guid Id)
        {
            return _hmsContext.Billings.FirstOrDefault(m => m.Id == Id);
        }


        public Billing? EditBilling(Billing billing)
        {
            Billing? existingbilling = GetBillingById(billing.Id);
            if (existingbilling != null)
            {
               existingbilling.Id = billing.Id;
                existingbilling.PatientId = billing.PatientId;
                existingbilling.DoctorId = billing.DoctorId;
                existingbilling.Amount = billing.Amount;
                existingbilling.BillingDate = billing.BillingDate;
                existingbilling.IsPaid = billing.IsPaid;
                
                //existingdepartment.Doctors = department.Doctors;

                _hmsContext.Billings.Update(existingbilling);
                _hmsContext.SaveChanges();
                return existingbilling;
            }
            return null;
        }

        public List<Billing> GetBilling(string search)
        {
            throw new NotImplementedException();
        }

        
        

       
    }
}
