using HMS.Abstractions;
using HMS.Extensions;
using HMS.Models;

namespace HMS.Services
{
    public class PatientServices : IPatientServices
    {
        private readonly HmsContext _hmsContext;
        public PatientServices(HmsContext hmsContext)
        {
            _hmsContext = hmsContext;
        }



        public List<Patient> GetPatient()
        {
            List<Patient> patient = _hmsContext.Patients.ToList();
            return patient;
        }
        public async Task<List<Patient>> GetPatients()
        {
            var patients = _hmsContext.Patients.Where(x => x.IsDeleted == null || x.IsDeleted == true).ToList();

            return patients;
        }
        public Patient? EditPatient(Patient patient)
        {
            Patient? existingpatient = GetPatientById(patient.Id);
            if (existingpatient != null)
            {
                existingpatient.Id = patient.Id;
                existingpatient.Name = patient.Name;
                existingpatient.Email = patient.Email;
                existingpatient.Gender = patient.Gender;
                existingpatient.ContactNumber = patient.ContactNumber;
                existingpatient.Email = patient.Email;
                existingpatient.DoctorId = patient.DoctorId;
                existingpatient.DischargeDate = patient.DischargeDate;
                existingpatient.Age = patient.Age;
                existingpatient.ProfilePictureId = patient.ProfilePictureId;
                _hmsContext.Patients.Update(existingpatient);
                _hmsContext.SaveChanges();
                return existingpatient;

            }
            return null;
        }




        public void AddPatient(Patient patient)
            {
            patient.Id = GuidExtension.NewGuid();
            patient.IsDeleted = true;
                _hmsContext.Patients.Add(patient);
            _hmsContext.SaveChanges();
            }

            public void DeletePatient(Patient patient)
            {
            patient.IsDeleted = false;
                _hmsContext.Patients.Update(patient);
            _hmsContext.SaveChanges();
            }

            public void DeletePatient(Guid Id)
            {
                Patient? patient = GetPatientById(Id);

                _hmsContext.Patients.Remove(patient);        
                    }

            public Patient? GetPatientById(Guid Id)
            {
                return _hmsContext.Patients.FirstOrDefault(p => p.Id == Id);
            }

        }
    }
