namespace Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

public class Patient
{
    public long Id { get; set; }
    public string Name { get; init; }
    public string Email { get; init; }
    public string Password { get; init; }
    public DateTime BirthDate { get; set; }
    public string ContactInfo { get; init; }
    public Perfil Perfil { get; init; }
}