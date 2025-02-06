using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Services;

public class AppointmentService(IAppointmentRepository appointmentRepository)
{
    public Task CreateAsync(CreateAppointmentRequest request)
    {
        var appointment = new Appointment()
        {
            DoctorId = request.DoctorId,
            PatientId = request.PatientId,
            AppointmentSlotId = request.AppointmentSlotId
        };
        
        return appointmentRepository.CreateAsync(appointment);
    }
}