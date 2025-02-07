using System.Threading.Tasks;
using HMS.Models;

namespace HMS.Abstractions
{
    public interface IDoctorterServices
    {
        List<Doctor> GetDoctors();
        void AddDoctor(Doctor doctor);
        Task<List<Doctor>> GetDoctor();
        Doctor? EditDoctor(Doctor doctor);

        void DeleteDoctor(Doctor doctor);

        void DeleteDoctor(Guid Id);

        Doctor? GetDoctorById(Guid Id);
       
        
       
    }
}
