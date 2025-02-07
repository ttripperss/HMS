using HMS.Abstractions;
using HMS.Extensions;
using HMS.Models;
using Microsoft.EntityFrameworkCore;

namespace HMS.Services
{
    public class DoctorServices : IDoctorterServices
    {
        private readonly HmsContext _hmsContext;
        private readonly IDepartmentServices _departmentServices;
        public DoctorServices(HmsContext hmsContext, IDepartmentServices departmentServices)
        {
            _hmsContext = hmsContext;
            _departmentServices = departmentServices;
        }

        public List<Doctor> GetDoctors()   //
        {
            List<Doctor> doctors = new List<Doctor>();
            return doctors;
        }
        public async Task<List<Doctor>> GetDoctor()
        {
            var doctor = _hmsContext.Doctors.Where(x => x.IsDeleted == null || x.IsDeleted == true).ToList();
            return doctor;
        }



        //public List<Doctor> GetDoctor(string search = null) {

        //    var  results = string.IsNullOrWhiteSpace(search)
        //         ? _doctors
        //        : _doctors.Where(p => p.Name != null && p.Name.Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
        //    return results;


        //}
        //public void AddDoctors(Doctor doctor) {
        //    doctor.Id = GuidExtension.NewGuid();
        //    doctor.IsDeleted = true;

        //    _hmsContext.Doctors.Add(doctor);
        //    _hmsContext.SaveChanges();
        //}

        public void DeleteDoctor(Doctor doctor) //
        {
            doctor.IsDeleted = false;
            _hmsContext.Doctors.Update(doctor);
            
            _hmsContext.SaveChanges();
        }
        
        public void DeleteDoctor(Guid id)   //
        {
          Doctor? doctor =  GetDoctorById(id);
            _hmsContext?.Doctors.Remove(doctor);

        }
        public Doctor? EditDoctor(Doctor doctor)
        {
            Doctor? existingdoctor = GetDoctorById(doctor.Id);
            if (existingdoctor != null)
            {
                existingdoctor.Id = doctor.Id;
                existingdoctor.Name = doctor.Name;
                existingdoctor.Email = doctor.Email;
                existingdoctor.DepartmentId = doctor.DepartmentId;
                existingdoctor.Experience = doctor.Experience;
                existingdoctor.Specialization = doctor.Specialization;

                _hmsContext.Doctors.Update(existingdoctor);
                _hmsContext.SaveChanges();
                return existingdoctor;
                
            }
            return null;
        }

        public Doctor? GetDoctorById(Guid Id)  //
        {
            return _hmsContext.Doctors.FirstOrDefault(m => m.Id == Id);
        }

        //public void CreateDoctor(Doctor doctor)
        //{
        //    // Add default values for new doctor
        //    doctor.Id = Guid.NewGuid();
        //    doctor.IsActive = true;
        //    doctor.IsDeleted = false;

        //    _hmsContext.Doctors.Add(doctor); // Add doctor to the database
        //    _hmsContext.SaveChanges();      // Save changes to the database
        //}


        public void AddDoctor(Doctor doctor)  //
        {
            doctor.Id = Guid.NewGuid();
            doctor.IsDeleted = true;
            _hmsContext.Doctors.Add(doctor);
            _hmsContext.SaveChanges();
        }
     
    }
}


