namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public record CreateDoctorRequest(string Name, string Crm, string Password, string Specialty, decimal AppointmentValue);