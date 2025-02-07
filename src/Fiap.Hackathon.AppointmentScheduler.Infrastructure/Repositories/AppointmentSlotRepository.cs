using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Enums;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Context;
using LinqKit;
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

    public async Task<IEnumerable<AppointmentSlot>> GetAvailableAppointment(long doctorId, DateTime availableDate)
    {
        var predicate = PredicateBuilder.New<AppointmentSlot>(true);

        predicate = predicate.And(a => a.DoctorId == doctorId);
        
        predicate = predicate.And(a => a.AvailableDate.Date == availableDate.Date);

        var slotAppointments =
            await dbContext.AppointmentSlots.Where(predicate).ToListAsync();

        var queryAppointments = dbContext.Appointments.Where(a =>
            a.DoctorId == doctorId && a.Status != AppointmentStatus.Canceled.ToString() &&
            slotAppointments.Select(sp => sp.Id).Contains(a.AppointmentSlotId));
        
        var appointments = await queryAppointments.ToListAsync();

        var appointmentSlots = new List<AppointmentSlot>();
        
        foreach(var slot in slotAppointments)
        {
            if(appointments.All(a => a.AppointmentSlotId != slot.Id))
            {
                appointmentSlots.Add(slot);
            }
        }

        return appointmentSlots;
    }
}