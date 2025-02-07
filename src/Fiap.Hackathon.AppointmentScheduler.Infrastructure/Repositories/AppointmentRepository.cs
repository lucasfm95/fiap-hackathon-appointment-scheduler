using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Enums;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

public class AppointmentRepository(AppointmentSchedulerDbContext dbContext) : IAppointmentRepository
{
    public async Task CreateAsync(Appointment appointment)
    {
        await dbContext.Appointments.AddAsync(appointment);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<Appointment>> GetAllScheduledAppointmentsByDoctor(long doctorId)
    {
        return await dbContext
            .Appointments.Where(a => a.DoctorId == doctorId && a.Status == AppointmentStatus.Scheduled.ToString())
            .ToListAsync();
    }
    
    public async Task<List<Appointment>> GetAllScheduledAppointmentsByPatient(long patientId)
    {
        return await dbContext
            .Appointments.Where(a => a.PatientId == patientId)
            .ToListAsync();
    }

    public async Task<int> UpdateStatusAsync(long appointmentId, AppointmentStatus status, string? justification)
    {
        return await dbContext.Appointments
            .Where(a => a.Id == appointmentId)
            .ExecuteUpdateAsync(prop => prop
                    .SetProperty(p => p.Status, status.ToString())
                    .SetProperty(p => p.Justification, justification));
    }
    
    public async Task<IEnumerable<Appointment>> GetByAppointmentSlot(long appointmentSlotId)
    {
        var slotAppointments =
            await dbContext.Appointments.Where(appointment => appointment.AppointmentSlotId == appointmentSlotId && appointment.Status != AppointmentStatus.Canceled.ToString()).ToListAsync();

        return slotAppointments;
    }
}