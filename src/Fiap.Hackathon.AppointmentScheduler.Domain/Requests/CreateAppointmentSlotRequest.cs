namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public record CreateAppointmentSlotRequest(long DoctorId, DateTime AvailableDate, DateTime AvailableTime);
