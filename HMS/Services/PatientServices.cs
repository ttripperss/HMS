using HMS.Abstractions;
using HMS.Data;
using HMS.Models;

namespace HMS.Services
{
    public class PatientServices : IPatientServices
    {
        private static List<Patient> _patients = Seed.Patient();
        public List<Patient> GetPatient(string? search = null)
        {
            var results = string.IsNullOrWhiteSpace(search)
                ? _patients
                : _patients.Where(p => p.Name != null && p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            return results;
        }

        public void AddPatient(Patient patient)
        {
            _patients.Add(patient);
        }

        public void DeletePatient(Patient patient)
        {
            _patients.Remove(patient);
        }

        public void DeletePatient(Guid Id)
        {
            Patient? patient = GetPatientById(Id);

            DeletePatient(patient);
        }

        public Patient? GetPatientById(Guid Id)
        {
            return _patients.FirstOrDefault(m => m.Id == Id);
        }

    }
}