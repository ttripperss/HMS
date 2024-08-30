using HMS.Abstractions;
using HMS.Data;
using HMS.Models;

namespace HMS.Services
{
    public class BillingServices : IBillingServices
    {

        public static List<Billing> _billing = Seed.billings();
        public static List<Billing> GetBillingByID(Guid? search = null)
        {
            var results = search == null
                ? _billing
                : _billing.Where(p => p.Id == search.Value).ToList();
            return results;
        }

        public void AddBilling(Billing billing) { 
        
        _billing.Add(billing);
         
        }
        public void RemoveBilling(Billing billing) { 
        
          _billing.Remove(billing);
                   
       }
        public void DeleteBilling(Guid Id)
        {

            if ((Billing?)GetBillingByID(Id) != null)
            {
                DeleteBilling((Billing?)GetBillingByID(Id));
            }
            else
            {
                // Optionally, handle the case where the billing record is not found
                // For example, log an error, throw an exception, etc.
                Console.WriteLine("Billing record not found.");
            }
        }

        private void DeleteBilling(Billing? billing)
        {
            throw new NotImplementedException();
        }

        public List<Billing> GetBilling(string search)
        {
            throw new NotImplementedException();
        }

        void IBillingServices.DeleteBilling(Billing billing)
        {
            throw new NotImplementedException();
        }

        public Patient? GetBillingById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
