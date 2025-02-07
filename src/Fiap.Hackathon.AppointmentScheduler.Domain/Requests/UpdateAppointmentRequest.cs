namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public record UpdateAppointmentRequest(long AppointmentId, string Status, string? Justification);