using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

public class DoctorRepository : IDoctorRepository
{
    private readonly List<Doctor> _doctors = new();
    public Task CreateAsync(Doctor doctor)
    {
        doctor.Id = _doctors.Count + 1;
        _doctors.Add(doctor);
        return Task.CompletedTask;
    }

    public Task<Doctor> GetDoctorByCrmAsync(string loginPatientCrm) => Task.FromResult(_doctors.First(d => d.Crm == loginPatientCrm));
    
    public Task<IEnumerable<Doctor>> GetAllAsync() => Task.FromResult(_doctors.AsEnumerable());
}