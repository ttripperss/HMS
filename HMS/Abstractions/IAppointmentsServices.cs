using HMS.Models;

namespace HMS.Abstractions
{
    public interface IAppointmentsServices
    {
        // List<Appointments> GetAppointments(string search);
        void AddAppointments(Appointment appointments);
        

        void DeleteAppointments(Appointment appointments);
        Task<List<Appointment>> GetAppointments();
        Appointment? EditAppointment(Appointment appointments);

           Appointment?  GetAppointmentsById( Guid Id);


        void DeleteAppointments(Guid Id);

     //    Appointments? GetAppointmentsById(Guid Id);

    }
}
