using HMS.Enum;
using HMS.Extensions;
using HMS.Models;

namespace HMS.Data
{
    public class Seed
    {
        public static List<Member> Member()
        {
            var member = new List<Member>
            {
                new Member{Id= GuidExtension.NewGuid(), Name = "Haris", ContactNumber="437937032",Email="hdlk@gmail.com"},
                new Member{Id= GuidExtension.NewGuid(), Name = "Ali", ContactNumber ="437677708832",Email="hail@gmail.com"}
            };
            return member;
        }


        public static List<Department> Department()
        {
            var department = new List<Department>
    {
        new Department { Id = GuidExtension.NewGuid(),
            Name = "john",
            ContactNumbers = "656383",
            HeaOfDepartment = "eyecare" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "mike",
            ContactNumbers = "99993",
            HeaOfDepartment = "mikeafther" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "cardiology",
            ContactNumbers = "123456",
            HeaOfDepartment = "Dr. Smith" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "neurology",
            ContactNumbers = "789101",
            HeaOfDepartment = "Dr. Johnson" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "orthopedics",
            ContactNumbers = "112233",
            HeaOfDepartment = "Dr. Davis" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "pediatrics",
            ContactNumbers = "445566",
            HeaOfDepartment = "Dr. Martinez" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "dermatology",
            ContactNumbers = "778899",
            HeaOfDepartment = "Dr. Lee" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "radiology",
            ContactNumbers = "223344",
            HeaOfDepartment = "Dr. Wilson" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "anesthesiology",
            ContactNumbers = "556677",
            HeaOfDepartment = "Dr. Patel" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "oncology",
            ContactNumbers = "889900",
            HeaOfDepartment = "Dr. Brown" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "psychiatry",
            ContactNumbers = "998877",
            HeaOfDepartment = "Dr. Clark" },

        new Department { Id = GuidExtension.NewGuid(),
            Name = "urology",
            ContactNumbers = "665544",
            HeaOfDepartment = "Dr. Miller" },
    };
            return department;
        }


        public static List<Patient> Patient()
        {
            var patients = new List<Patient>
    {
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "Haris",
            Age = 30,
            Gender = Enum.Gender.Male,
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
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-10),
            DischargeDate = DateTime.Now.AddDays(10)
        },
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "Ayesha",
            Age = 25,
            Gender = Enum.Gender.Female,
            ContactNumber = "33333",
            Email = "ayesha@example.com",
            Address = new Address
            {
                Street = "456 Maple Avenue",
                City = "Shelbyville",
                Zipcode = "67890",
                Country = "USA",
                State = "IN"
            },
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-5),
            DischargeDate = DateTime.Now.AddDays(5)
        },
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "John",
            Age = 40,
            Gender = Enum.Gender.Male,
            ContactNumber = "44444",
            Email = "john@example.com",
            Address = new Address
            {
                Street = "789 Oak Drive",
                City = "Capital City",
                Zipcode = "10112",
                Country = "USA",
                State = "NY"
            },
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-20),
            DischargeDate = DateTime.Now.AddDays(-10)
        },
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "Sarah",
            Age = 35,
            Gender = Enum.Gender.Female,
            ContactNumber = "55555",
            Email = "sarah@example.com",
            Address = new Address
            {
                Street = "101 Pine Lane",
                City = "Ogdenville",
                Zipcode = "11121",
                Country = "USA",
                State = "CA"
            },
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-15),
            DischargeDate = DateTime.Now.AddDays(-5)
        },
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "David",
            Age = 28,
            Gender = Enum.Gender.Male,
            ContactNumber = "66666",
            Email = "david@example.com",
            Address = new Address
            {
                Street = "102 Birch Boulevard",
                City = "North Haverbrook",
                Zipcode = "13141",
                Country = "USA",
                State = "TX"
            },
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-2),
            DischargeDate = DateTime.Now.AddDays(12)
        },
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "Emma",
            Age = 22,
            Gender = Enum.Gender.Female,
            ContactNumber = "77777",
            Email = "emma@example.com",
            Address = new Address
            {
                Street = "104 Cedar Court",
                City = "Brockway",
                Zipcode = "15161",
                Country = "USA",
                State = "FL"
            },
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-8),
            DischargeDate = DateTime.Now.AddDays(2)
        },
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "Michael",
            Age = 45,
            Gender = Enum.Gender.Male,
            ContactNumber = "88888",
            Email = "michael@example.com",
            Address = new Address
            {
                Street = "201 Walnut Street",
                City = "Ogdenville",
                Zipcode = "16171",
                Country = "USA",
                State = "WA"
            },
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-12),
            DischargeDate = DateTime.Now.AddDays(-2)
        },
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "Olivia",
            Age = 33,
            Gender = Enum.Gender.Female,
            ContactNumber = "99999",
            Email = "olivia@example.com",
            Address = new Address
            {
                Street = "202 Hickory Hill",
                City = "Springfield",
                Zipcode = "17181",
                Country = "USA",
                State = "NV"
            },
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-7),
            DischargeDate = DateTime.Now.AddDays(3)
        },
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "Sophia",
            Age = 29,
            Gender = Enum.Gender.Female,
            ContactNumber = "10101",
            Email = "sophia@example.com",
            Address = new Address
            {
                Street = "203 Elm Street",
                City = "Shelbyville",
                Zipcode = "18191",
                Country = "USA",
                State = "CO"
            },
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-18),
            DischargeDate = DateTime.Now.AddDays(-8)
        },
        new Patient
        {
            Id = GuidExtension.NewGuid(),
            Name = "Daniel",
            Age = 31,
            Gender = Enum.Gender.Male,
            ContactNumber = "11111",
            Email = "daniel@example.com",
            Address = new Address
            {
                Street = "204 Maple Avenue",
                City = "Capital City",
                Zipcode = "20202",
                Country = "USA",
                State = "OH"
            },
            DoctorID = GuidExtension.NewGuid(),
            AdmissionDate = DateTime.Now.AddDays(-13),
            DischargeDate = DateTime.Now.AddDays(-3)
        }
    };

            return patients;
        }


        public static List<Doctor> Doctors()
        {
            var doctors = new List<Doctor>
    {
        new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. John Doe",
            Contactnumber = 343,
            Email = "john.doe@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 15,
            Specialization = Specialization.Cardiology
        },
        new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. Jane Smith",
            Contactnumber = 456,
            Email = "jane.smith@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 10,
            Specialization = Specialization.Neurology
        },
        new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. Robert Brown",
            Contactnumber = 567,
            Email = "robert.brown@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 8,
            Specialization = Specialization.Orthopedics
        },
        new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. Emily Davis",
            Contactnumber = 678,
            Email = "emily.davis@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 12,
            Specialization = Specialization.Pediatrics
        },
        new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. Michael Lee",
            Contactnumber = 789,
            Email = "michael.lee@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 7,
            Specialization = Specialization.Dermatology
        },
        new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. Sarah Martinez",
            Contactnumber = 890,
            Email = "sarah.martinez@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 9,
            Specialization = Specialization.Radiology
        },
        new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. David Wilson",
            Contactnumber = 901,
            Email = "david.wilson@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 14,
            Specialization = Specialization.Anesthesiology
        },
        new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. Laura Clark",
            Contactnumber = 123,
            Email = "laura.fd@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 11,
            Specialization = Specialization.Oncology
        },new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. Hakim",
            Contactnumber = 13,
            Email = "laura.cl@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 31,
            Specialization = Specialization.Oncology
        },new Doctor
        {
            Id = GuidExtension.NewGuid(),
            Name = "Dr. Usama",
            Contactnumber = 333,
            Email = "laura.ck@example.com",
            DepartmentID = GuidExtension.NewGuid(),
            Experience = 55,
            Specialization = Specialization.Oncology
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
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            Amount = 5000.00m,
            BillingDate = DateTime.Now,
            IsPaid = false
        },
        new Billing
        {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            Amount = 7500.00m,
            BillingDate = DateTime.Now.AddDays(-10),
            IsPaid = true
        },
        new Billing
        {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            Amount = 6000.00m,
            BillingDate = DateTime.Now.AddDays(-5),
            IsPaid = false
        },
        new Billing
        {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            Amount = 8200.00m,
            BillingDate = DateTime.Now.AddDays(-20),
            IsPaid = true
        },
        new Billing
        {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            Amount = 4500.00m,
            BillingDate = DateTime.Now.AddDays(-15),
            IsPaid = false
        },
        new Billing
        {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            Amount = 7000.00m,
            BillingDate = DateTime.Now.AddDays(-7),
            IsPaid = true
        },
        new Billing
        {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            Amount = 5500.00m,
            BillingDate = DateTime.Now.AddDays(-2),
            IsPaid = false
        },
        new Billing
        {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            Amount = 9000.00m,
            BillingDate = DateTime.Now.AddDays(-30),
            IsPaid = true
        }
    };

            return billing;
        }


        public static List<Appointments> Appointments()
        {


            var appointments = new List<Appointments>
            {
                new Appointments
                {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            AppointmentDate = DateTime.Now.AddDays(1),
            Purpose = "Routine Checkup",
            IsCompleted = false
        },
        new Appointments
        {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
            AppointmentDate = DateTime.Now.AddDays(2),
            Purpose = "Follow-up on surgery",
            IsCompleted = false
        },
        new Appointments
        {
            Id = GuidExtension.NewGuid(),
            PatientId = GuidExtension.NewGuid(), // Replace with actual Patient ID
            DoctorId = GuidExtension.NewGuid(),  // Replace with actual Doctor ID
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