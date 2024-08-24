using Humanizer;

namespace HMS.Models
{
    public class Patient
    {

         public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age {  get; set; }

        public  string  Gender {  get; set; }
       public string ContactNumber {  get; set; }
        public string Email {  get; set; }

        public Address Address {  get; set; }    
         
        public Guid DoctorID { get; set; }
        public DateTime AdmissionDate { get; set; }

        public DateTime DischargeDate { get; set; }
        public Guid DoctorId { get;  set; }
    }
    
}
public class Address
{
    public string    Street { get; set; }
    public string   City { get; set; }
    public string Zipcode { get; set; }
    public string ZipCode { get; internal set; }
    public string Country { get; set; }
    public string State { get; internal set; }

   
}