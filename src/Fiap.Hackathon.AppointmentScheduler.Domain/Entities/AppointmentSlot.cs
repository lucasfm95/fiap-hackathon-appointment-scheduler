using System.Text.Json.Serialization;

namespace Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

public class AppointmentSlot
{
    public long Id { get; init; }
    
    [JsonIgnore]
    public long DoctorId { get; init; }
    public Doctor Doctor { get; init; }
    public DateTime AvailableDate { get; init; }
    public TimeSpan AvailableTime { get; init; }
}