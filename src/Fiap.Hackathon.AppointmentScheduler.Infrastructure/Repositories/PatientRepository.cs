using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly List<Patient> _patients = new();
    public Task CreateAsync(Patient patient)
    {
        patient.Id = _patients.Count + 1;
        _patients.Add(patient);
        return Task.CompletedTask;
    }

    public Task<Patient> GetPatientByEmail(string email) => Task.FromResult(_patients.First(p => p.Email == email));
    
    public Task<IEnumerable<Patient>> GetAllAsync() => Task.FromResult(_patients.AsEnumerable());
}