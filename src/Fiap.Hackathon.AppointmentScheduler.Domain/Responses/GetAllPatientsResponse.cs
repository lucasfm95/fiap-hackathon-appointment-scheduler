namespace Fiap.Hackathon.AppointmentScheduler.Domain.Responses;

public record GetAllPatientsResponse(long Id, string Name, string Email, string Cpf);