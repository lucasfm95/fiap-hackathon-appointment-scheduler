using Fiap.Hackathon.AppointmentScheduler.Domain;

namespace Fiap.Hackathon.AppointmentScheduler.Application.Dtos;

public record DoctorDto(string Name, string Crm, string Password, string Specialty, string ContactInfo);