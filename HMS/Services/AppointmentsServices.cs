
using HMS.Abstractions;
using HMS.Models;

namespace HMS.Services
{
    public class AppointmentServices : IAppointmentsServices
    {
        private readonly HmsContext _hmsContext;
        public AppointmentServices(HmsContext hmsContext)
        {
            _hmsContext = hmsContext;
            
        }
        public async Task<List<Appointment>> GetAppointments()
        {
            var appointments = _hmsContext.Appointments.ToList();
            return appointments;

            }
        //public List<Appointment> GetAppointment(string? search = null)
        //{
        //    var results = string.IsNullOrWhiteSpace(search)
        //? _appointments
        //: _appointments.Where(predicate: p =>
        //{
        //    return p.Id != null
        //    && p.Id.ToString().Contains(search, StringComparison.OrdinalIgnoreCase);
        //}).ToList();
        //    return results; ;
        //}
        public Appointment? EditAppointment(Appointment appointments)
        {
            Appointment? existingappointments = GetAppointmentsById(appointments.Id);
            if (existingappointments != null)
            {
                existingappointments.Id = appointments.Id;
                existingappointments.PatientId = appointments.PatientId;
                existingappointments.DoctorId = appointments.DoctorId;
                existingappointments.AppointmentDate = appointments.AppointmentDate;
                existingappointments.Purpose = appointments.Purpose;
                existingappointments.IsCompleted = appointments.IsCompleted;
                //existingappointments.DateTime = existingappointments.DateTime;
                    
                return existingappointments;
            }
            return null;
        }


        public void AddAppointments(Appointment appointments)
        {
            
            _hmsContext.Appointments.Add(appointments);
        }

        public void DeleteAppointments(Appointment appointments)
        {
            _hmsContext.Remove(appointments);
        }

        public void DeleteAppointments(Guid Id)
        {
            Appointment? appointments = GetAppointmentsById(Id);

            _hmsContext.Appointments.Remove(appointments);
        }

        public Appointment? GetAppointmentsById(Guid Id)
        {
            return _hmsContext.Appointments.FirstOrDefault(m => m.Id == Id);
        }

    }
}

