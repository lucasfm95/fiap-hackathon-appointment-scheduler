using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Repositories;

public interface IAppointmentSlotRepository
{
    Task CreateAsync(AppointmentSlot doctor);
    Task<IEnumerable<AppointmentSlot>> GetAllAsync();
    
    Task DeleteAsync(long id);
}