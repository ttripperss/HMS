namespace HMS.Models
{
    public  class Appointments
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PatientId { get; set; } = Guid.NewGuid();
        public Guid DoctorId { get; set; } = Guid.NewGuid();
        public DateTime AppointmentDate { get; set; }
        public string Purpose { get; set; }
        public bool IsCompleted { get; set; } = false;


       
        

        
    }
}