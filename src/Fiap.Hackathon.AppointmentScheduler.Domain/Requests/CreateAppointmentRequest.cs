namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public record CreateAppointmentRequest(long DoctorId, long PatientId, long AppointmentSlotId);