using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;
using Fiap.Hackathon.AppointmentScheduler.Domain.Responses;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Services;

public class AppointmentSlotService(IAppointmentSlotRepository appointmentSlotRepository)
{
    
    public Task CreateAsync(long doctorId, CreateAppointmentSlotRequest request)
    {
        var appointmentSlot = new AppointmentSlot()
        {
            DoctorId = doctorId,
            AvailableDate = request.AvailableDate,
            AvailableTime = request.AvailableTime.TimeOfDay
        };
        
        return appointmentSlotRepository.CreateAsync(appointmentSlot);
    }
    
    public async Task<IEnumerable<GetAllAppointmentSlotsResponse>> GetAll()
    {
        var appointmentSlots = await appointmentSlotRepository.GetAllAsync();
        return appointmentSlots.Select(appointmentSlot => 
            new GetAllAppointmentSlotsResponse(appointmentSlot.Id, appointmentSlot.Doctor, appointmentSlot.AvailableDate, appointmentSlot.AvailableTime));
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