namespace Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

public class Patient
{
    public long Id { get; set; }
    public string Name { get; init; }
    public string Email { get; init; }

    public string Cpf { get; set; }
    public Profile Profile { get; init; }
    public string Password { get; init; }
}