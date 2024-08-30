using HMS.Models;

namespace HMS.Abstractions
{
    public interface IDoctorterServices
    {
        List<Doctor> GetDoctors(string search);
        void AddDoctor(Doctor doctor);

        void DeleteDoctor(Doctor doctor);

        void DeleteDoctor(Guid Id);

        Patient? GetDoctorById(Guid Id);
    }
}
