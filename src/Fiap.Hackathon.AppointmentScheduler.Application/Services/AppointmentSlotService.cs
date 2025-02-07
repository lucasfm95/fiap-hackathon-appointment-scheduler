using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;
using Fiap.Hackathon.AppointmentScheduler.Domain.Responses;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Services;

public class AppointmentSlotService(IAppointmentSlotRepository appointmentSlotRepository)
{
    
    public Task CreateAsync(CreateAppointmentSlotRequest request)
    {
        var appointmentSlot = new AppointmentSlot()
        {
            DoctorId = request.DoctorId,
            AvailableDate = request.AvailableDate,
            AvailableTime = request.AvailableTime.TimeOfDay
        };
        
        return appointmentSlotRepository.CreateAsync(appointmentSlot);
    }
    
    public async Task<IEnumerable<GetAllAppointmentSlotsResponse>> GetAll()
    {
        var appointmentSlots = await appointmentSlotRepository.GetAllAsync();
        return appointmentSlots.Select(a => new GetAllAppointmentSlotsResponse(a.Id, a.Doctor, a.AvailableDate, a.AvailableTime));
    }
    
    public async Task DeleteAsync(long id)
    {
        await appointmentSlotRepository.DeleteAsync(id);
    }

    public async Task<IEnumerable<AppointmentSlot>> GetAvailableAppointment(int doctorId, DateTime appointmentDate)
    {
        return await appointmentSlotRepository.GetAvailableAppointment(doctorId, appointmentDate);
    }
}