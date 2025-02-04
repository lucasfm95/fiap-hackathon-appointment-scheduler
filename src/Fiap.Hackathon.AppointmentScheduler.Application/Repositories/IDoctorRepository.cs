using Fiap.Hackathon.AppointmentScheduler.Domain;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Repositories;

public interface IDoctorRepository
{
    Task CreateAsync(Doctor doctor);
    Task<Doctor> GetDoctorByCrmAsync(string loginPatientCrm);
    Task<IEnumerable<Doctor>> GetAllAsync();
}