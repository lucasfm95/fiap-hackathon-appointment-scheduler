using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Context;
using LinqKit;
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

    public Task<IEnumerable<Doctor>> GetFiltered(string? specialty, string? name, string? crm)
    {
        var predicate = PredicateBuilder.New<Doctor>(true);

        if (!string.IsNullOrEmpty(specialty))
        {
            predicate = predicate.And(d => EF.Functions.ILike(d.Specialty, $"%{specialty}%"));
        }

        if (!string.IsNullOrEmpty(name))
        {
            predicate = predicate.And(d => EF.Functions.ILike(d.Name, $"%{name}%"));
        }

        if (!string.IsNullOrEmpty(crm))
        {
            predicate = predicate.And(d => EF.Functions.ILike(d.Crm, $"%{crm}%"));
        }

        return Task.FromResult(dbContext.Doctors.AsExpandable().Where(predicate).AsEnumerable());
    }
}