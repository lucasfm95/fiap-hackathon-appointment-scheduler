using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Exceptions;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Services;

public class AppointmentService(IAppointmentRepository appointmentRepository)
{
    public async Task CreateAsync(CreateAppointmentRequest request)
    {
        var appointment = new Appointment()
        {
            DoctorId = request.DoctorId,
            PatientId = request.PatientId,
            AppointmentSlotId = request.AppointmentSlotId
        };
        
        var appointments = await appointmentRepository.GetByAppointmentSlot(request.AppointmentSlotId);
        if (appointments.Any())
        {
            throw new DuplicateAppointmentException();
        }
        
        await appointmentRepository.CreateAsync(appointment);
    }
    
    public Task UpdateStatusAsync(long appointmentId, string status, string? justification)
    {
        return appointmentRepository.UpdateStatusAsync(appointmentId, status, justification);
    }
    
    public Task<List<Appointment>> GetAllScheduledAppointmentsByDoctor(long doctorId)
    {
        return appointmentRepository.GetAllScheduledAppointmentsByDoctor(doctorId);
    }
    
    public Task<List<Appointment>> GetAllScheduledAppointmentsByPatient(long patientId)
    {
        return appointmentRepository.GetAllScheduledAppointmentsByPatient(patientId);
    }
}