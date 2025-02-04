namespace Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

public class Doctor
{
    public long Id { get; set; }
    public string Name { get; init; }
    public string Crm { get; init; }
    public string Password { get; init; }
    public string Specialty { get; init; }
    public string ContactInfo { get; init; }
    public Perfil Perfil { get; init; }
}