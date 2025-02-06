using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

public class AppointmentSlotRepository(AppointmentSchedulerDbContext dbContext) : IAppointmentSlotRepository
{
    public async Task CreateAsync(AppointmentSlot appointmentSlot)
    {
        await dbContext.AppointmentSlots.AddAsync(appointmentSlot);
        await dbContext.SaveChangesAsync();
    }

    public Task<IEnumerable<AppointmentSlot>> GetAllAsync()
    {
        return Task.FromResult(dbContext.AppointmentSlots.Include(a => a.Doctor).AsEnumerable());
    }
    
    
    public async Task DeleteAsync(long id)
    {
        var appointmentSlot = await dbContext.AppointmentSlots.FindAsync(id);
        if (appointmentSlot != null)
        {
            dbContext.AppointmentSlots.Remove(appointmentSlot);
            await dbContext.SaveChangesAsync();
        }
    }
    
}