namespace HMS.Models
{
    public class Doctor
    {
        public Specialization Specialization {  get; set; }

        public Guid Id { get; set; }
        public string Name { get; set; }
        
        public int Contactnumber { get; set; }
        public string Email { get; set; }

        public Guid DepartmentID { get; set; }
        public int Experience { get; internal set; }
        public string ContactNumber { get; internal set; }
        public Guid DepartmentId { get; internal set; }
    }

}
public enum Specialization
{
    Cardiology,
    Neurology,
    GeneralMedicine,
    Orthopedics,
    etc
}