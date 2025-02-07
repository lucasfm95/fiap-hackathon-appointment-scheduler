using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

public class PatientRepository(AppointmentSchedulerDbContext dbContext) : IPatientRepository
{
    public async Task CreateAsync(Patient patient)
    {
        await dbContext.Patients.AddAsync(patient);
        await dbContext.SaveChangesAsync();
    }

    public Task<Patient> GetPatientByEmail(string email) => dbContext.Patients.FirstAsync(p => p.Email == email);
    
    public Task<IEnumerable<Patient>> GetAllAsync() => Task.FromResult(dbContext.Patients.AsEnumerable());
    
    public Task<Patient> GetPatientByCpf(string cpf) => dbContext.Patients.FirstAsync(p => p.Cpf == cpf);
}