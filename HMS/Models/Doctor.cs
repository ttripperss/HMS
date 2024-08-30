using HMS.Enum;

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
        public int Experience { get; set; }
        
        public Guid DepartmentId { get;  set; }
       
    }

}
