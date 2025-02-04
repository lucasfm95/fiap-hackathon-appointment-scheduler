namespace Fiap.Hackathon.AppointmentScheduler.Application.Dtos;

public record PatientDto(string Name, string Email, string Password, DateTime BirthDate, string ContactInfo);