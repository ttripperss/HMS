using HMS.Models;

namespace HMS.Abstractions
{
    public interface IPatientServices
    {
        // sab method declare karna ha
        List<Patient> GetPatient(string? search);
        void AddPatient(Patient patient);

        void DeletePatient(Patient patient);

        void DeletePatient(Guid Id);

        Patient? GetPatientById(Guid Id);
    }
}
