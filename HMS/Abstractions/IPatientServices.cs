 using HMS.Models;

namespace HMS.Abstractions
{
    public interface IPatientServices
    {

        // sab method declare karna ha
        List<Patient> GetPatient();
        void AddPatient(Patient patient);
        Task<List<Patient>> GetPatients();
        Patient? EditPatient(Patient patient);
        void DeletePatient(Patient patient);

        void DeletePatient(Guid Id);
       

        Patient? GetPatientById(Guid Id);
    }
}
