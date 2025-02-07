using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Repositories;

public interface IAppointmentRepository
{
    Task CreateAsync(Appointment appointment);

    Task<List<Appointment>> GetAllScheduledAppointmentsByDoctor(long doctorId);
    
    Task<int> UpdateStatusAsync(long appointmentId, string status, string? justification);
}