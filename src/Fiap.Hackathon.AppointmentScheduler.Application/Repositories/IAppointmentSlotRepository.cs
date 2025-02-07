using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Repositories;

public interface IAppointmentSlotRepository
{
    Task CreateAsync(AppointmentSlot doctor);
    Task<IEnumerable<AppointmentSlot>> GetAllAsync();
    Task<IEnumerable<AppointmentSlot>> GetAvailableAppointment(long doctorId, DateTime availableDate);
    Task DeleteAsync(long id);
}