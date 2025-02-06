using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Infrastructure.Context;

namespace Fiap.Hackathon.AppointmentScheduler.Infrastructure.Repositories;

public class AppointmentRepository(AppointmentSchedulerDbContext dbContext) : IAppointmentRepository
{
    public async Task CreateAsync(Appointment appointment)
    {
        await dbContext.Appointments.AddAsync(appointment);
        await dbContext.SaveChangesAsync();
    }
}