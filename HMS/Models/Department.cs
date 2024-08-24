namespace HMS.Models
{
    public sealed class Department
    {
        public  Guid Id { get; set; }
        public string Name { get; set; }=string.Empty;
        public string HeaOfDepartment { get; set; }= string.Empty;
        public string ContactNumbers { get; set; } = string.Empty;

       public List<Doctor> Doctors { get; set; }
        
        

        public Department()
        {
            Doctors = new List<Doctor>();
            Id = Guid.NewGuid();
        }
    
    }
}
