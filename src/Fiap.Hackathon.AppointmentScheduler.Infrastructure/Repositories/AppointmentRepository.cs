using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
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
            .Appointments.Where(a => a.DoctorId == doctorId && a.Status!.Equals("AGENDADO"))
            .ToListAsync();
    }

    public async Task<int> UpdateStatusAsync(long appointmentId, string status, string? justification)
    {
        return await dbContext.Appointments
            .Where(a => a.Id == appointmentId)
            .ExecuteUpdateAsync(prop => prop
                    .SetProperty(p => p.Status, status)
                    .SetProperty(p => p.Justification, justification));
    }
}