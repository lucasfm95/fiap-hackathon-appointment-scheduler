namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public record CreatePatientRequest(string Name, string Email, string Password, string Cpf);