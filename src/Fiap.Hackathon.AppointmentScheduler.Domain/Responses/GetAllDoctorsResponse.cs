namespace Fiap.Hackathon.AppointmentScheduler.Domain.Responses;

public record GetAllDoctorsResponse(long Id, string Name, string Crm, string Specialty);