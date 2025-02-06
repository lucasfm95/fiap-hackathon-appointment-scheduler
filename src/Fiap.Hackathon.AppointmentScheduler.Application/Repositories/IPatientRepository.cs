using Fiap.Hackathon.AppointmentScheduler.Domain;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Repositories;

public interface IPatientRepository
{
    Task CreateAsync(Patient patient);
    Task<Patient> GetPatientByEmail(string email);
    Task<IEnumerable<Patient>> GetAllAsync();
    Task<Patient> GetPatientByCpf(string cpf);
}