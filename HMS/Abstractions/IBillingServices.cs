using HMS.Models;

namespace HMS.Abstractions
{
    public interface IBillingServices
    {
        List<Billing> GetBilling(string search);
        void AddBilling(Billing billing);

        void DeleteBilling(Billing billing);

        void DeleteBilling(Guid Id);

        Patient? GetBillingById(Guid Id);
    }
}
