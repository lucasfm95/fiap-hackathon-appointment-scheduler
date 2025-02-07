using Fiap.Hackathon.AppointmentScheduler.Domain.Enums;

namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public record UpdateAppointmentRequest(long AppointmentId, AppointmentStatus Status, string? Justification);