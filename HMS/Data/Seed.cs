using HMS.Models;

namespace HMS.Data
{
    public class Seed
    {
        public static List<Member> Member()
        {
            var member = new List<Member>
            {
                new Member{Id= Guid.NewGuid, Name = "Haris", ContactNumber="437937032",Email="hdlk@gmail.com"},
                new Member{Id= Guid.NewGuid, Name = "Ali", ContactNumber ="437677708832",Email="hail@gmail.com"}
            };
            return member;
        }


        public static List<Department> Department()
        {
            var department = new List<Department>
            {
                new Department { Id = Guid.NewGuid(), 
                    Name = "john",
                    ContactNumbers = "656383", HeaOfDepartment = "eyecare" },
                new Department { Id = Guid.NewGuid(), 
                    Name = "mike", ContactNumbers = "99993", HeaOfDepartment = "mikeafther" },


            };
            return department;
        }


        public static List<Patient> Patient()
        {
            var patient = new List<Patient>
            {
                new Patient
                {
            Id = Guid.NewGuid(),
            Name = "Haris",
            Age = 30,
            Gender = "Male",
            ContactNumber = "22222",
            Email = "haris@example.com",
            Address = new Address
            {
                Street = "123 Elm Street",
                City = "Springfield",
                Zipcode = "12345",
                Country = "USA",
                State = "IL"
            },
            DoctorID = Guid.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-10),
            DischargeDate = DateTime.Now.AddDays(10)


                }

            };
            return patient;

        }

        public static List<Doctor> doctors()
        {
            var doctors = new List<Doctor>
            {
                new Doctor{
                Id = Guid.NewGuid(),
                Name = "Dr. John Doe",
                ContactNumber = "123456789",
                Email = "john.doe@example.com",
                DepartmentID = Guid.NewGuid(),
                Experience = 15,
                Specialization = Specialization.Cardiology


                }
                };

            return doctors;

        }

        public static List<Billing> billings()
        {
            var billing = new List<Billing>
            {
                new Billing
             {
            Id = Guid.NewGuid(),
            PatientId = Guid.NewGuid(), // Replace with actual Patient ID
            DoctorId = Guid.NewGuid(),  // Replace with actual Doctor ID
            Amount = 5000.00m,
            BillingDate = DateTime.Now,
            IsPaid = false
        },
        new Billing
        {
            Id = Guid.NewGuid(),
            PatientId = Guid.NewGuid(), // Replace with actual Patient ID
            DoctorId = Guid.NewGuid(),  // Replace with actual Doctor ID
            Amount = 7500.00m,
            BillingDate = DateTime.Now.AddDays(-10),
            IsPaid = true
        },
        // Add more billing instances as needed
    };
            return billing;

        }

        public static List<Appointment> Appointments()
        {


            var appointments = new List<Appointment>
            {
                new Appointment
                {
            Id = Guid.NewGuid(),
            PatientId = Guid.NewGuid(), // Replace with actual Patient ID
            DoctorId = Guid.NewGuid(),  // Replace with actual Doctor ID
            AppointmentDate = DateTime.Now.AddDays(1),
            Purpose = "Routine Checkup",
            IsCompleted = false
        },
        new Appointment
        {
            Id = Guid.NewGuid(),
            PatientId = Guid.NewGuid(), // Replace with actual Patient ID
            DoctorId = Guid.NewGuid(),  // Replace with actual Doctor ID
            AppointmentDate = DateTime.Now.AddDays(2),
            Purpose = "Follow-up on surgery",
            IsCompleted = false
        },
        new Appointment
        {
            Id = Guid.NewGuid(),
            PatientId = Guid.NewGuid(), // Replace with actual Patient ID
            DoctorId = Guid.NewGuid(),  // Replace with actual Doctor ID
            AppointmentDate = DateTime.Now.AddDays(-7),
            Purpose = "Consultation for recurring symptoms",
            IsCompleted = true
        },
        // Add more appointment instances as needed
    };

            return appointments;



        }
    }
}