
namespace HMS.Models
{
    public class Billing
    {
        public Guid Id { get; set; } 
        public Guid PatientId { get; set; }
        public Guid DoctorId { get; set; }
        public decimal Amount { get; set; }
        public DateTime BillingDate { get; set; }
        public bool IsPaid { get; set; } = false;

        public static explicit operator Billing(List<Billing> v)
        {
            throw new NotImplementedException();
        }
    }
}
