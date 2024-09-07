using HMS.Models;

namespace HMS.Abstractions
{
    public interface IBillingServices
    {
        List<Billing> GetBilling(string search);

        Billing? EditBilling(Billing billing);

        Task<List<Billing>> GetBillings();
        void AddBilling(Billing billing);

        void DeleteBilling(Billing billing);

        void DeleteBilling(Guid Id);

        Billing? GetBillingById(Guid Id);
    }
}
