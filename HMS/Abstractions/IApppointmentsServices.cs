using HMS.Models;

namespace HMS.Abstractions
{
    public interface IApppointmentsServices
    {
        List<Appointments> GetAppointments(string search);
        void AddAppointments(Appointments appointments);

        void DeleteAppointments(Appointments appointments);

        void DeleteAppointments(Guid Id);

        Appointments? GetAppointmentsById(Guid Id);

    }
}
