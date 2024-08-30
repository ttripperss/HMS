using HMS.Data;
using HMS.Models;

namespace HMS.Services
{
    public class AppointmentsServices : IAppointmentServices
    {
        private static List<Appointments> _appointments = Seed.Appointments();
        public List<Appointments> GetAppointments(string? search = null)
        {
            var results = string.IsNullOrWhiteSpace(search)
        ? _appointments
        : _appointments.Where(p => p.Id != null && p.Id.ToString().Contains(search, StringComparison.OrdinalIgnoreCase)).ToList();
            return results; ;
        }

        public void AddAppointments(Appointments appointments)
        {
            _appointments.Add(appointments);
        }

        public void DeleteAppointments(Appointments appointments)
        {
            _appointments.Remove(appointments);
        }

        public void DeleteAppointments(Guid Id)
        {
            Appointments? appointments = GetAppoiontmentsById(Id);

            DeleteAppointments(appointments);
        }

        public Appointments? GetAppoiontmentsById(Guid Id)
        {
            return _appointments.FirstOrDefault(m => m.Id == Id);
        }

    }
}

