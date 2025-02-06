using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;

namespace Fiap.Hackathon.AppointmentScheduler.Domain.Responses;

public record GetAllAppointmentSlotsResponse(Doctor? Doctor, DateTime AvailableDate, TimeSpan AvailableTime)
{
    
}