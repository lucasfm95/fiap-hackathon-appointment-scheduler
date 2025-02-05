namespace Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

public class AppointmentSlot
{
    public long Id { get; set; }
    public long DoctorId { get; init; }
    public Doctor? Doctor { get; init; }
    public DateTime AvailableDate { get; init; }
    public DateTime AvailableTime { get; init; }
}