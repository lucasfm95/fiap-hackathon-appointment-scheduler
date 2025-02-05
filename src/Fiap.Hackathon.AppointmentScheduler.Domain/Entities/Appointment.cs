namespace Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

public class Appointment
{
    public long Id { get; set; }
    public long DoctorId { get; set; }
    public Doctor Doctor { get; init; }
    public long PatientId { get; set; }
    public Patient Patient { get; init; }
    public long AppointmentSlotId { get; set; }
    public AppointmentSlot AppointmentSlot { get; set; }
    public string Status { get; init; }
    public string Justification { get; init; }
}