using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Repositories;

public interface IAppointmentRepository
{
    Task CreateAsync(Appointment appointment);
}