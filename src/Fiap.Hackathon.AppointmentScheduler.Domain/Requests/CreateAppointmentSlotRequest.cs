namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public record CreateAppointmentSlotRequest( DateTime AvailableDate, DateTime AvailableTime);
