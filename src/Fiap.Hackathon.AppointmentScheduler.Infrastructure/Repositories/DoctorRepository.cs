using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

public class DoctorRepository(AppointmentSchedulerDbContext dbContext) : IDoctorRepository
{
    public async Task CreateAsync(Doctor doctor)
    {
        await dbContext.Doctors.AddAsync(doctor);
        await dbContext.SaveChangesAsync();
    }

    public Task<Doctor> GetDoctorByCrmAsync(string crm) => dbContext.Doctors.FirstAsync(d => d.Crm == crm);
    
    public Task<IEnumerable<Doctor>> GetAllAsync() => Task.FromResult(dbContext.Doctors.AsEnumerable());
}