using HMS.Abstractions;
using HMS.Data;
using HMS.Models;

namespace HMS.Services
{
    public class DoctorServices : IDoctorterServices
    {
        private static List<Doctor> _doctors  = Seed.Doctors();

        public List<Doctor> GetDoctor(string search = null) {
            
            var  results = string.IsNullOrWhiteSpace(search)
                 ? _doctors
                : _doctors.Where(p => p.Name != null && p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            return results;


        }
        public void AddDoctors(Doctor doctor) {
            _doctors.Add(doctor);
                   }

        public void DeleteDoctor(Doctor doctor)
        {

            _doctors.Remove(doctor);
        }
        public void DeleteDoctor(Guid Id)
        {
            Doctor? doctor = GetDoctorById(Id);

            DeleteDoctor(doctor);
        }

        public Doctor? GetDoctorById(Guid Id)
        {
            return _doctors.FirstOrDefault(m => m.Id == Id);
        }

        public List<Doctor> GetDoctors(string search)
        {
            throw new NotImplementedException();
        }

        public void AddDoctor(Doctor doctor)
        {
            throw new NotImplementedException();
        }

        Patient? IDoctorterServices.GetDoctorById(Guid Id)
        {
            throw new NotImplementedException();
        }
    }
}
