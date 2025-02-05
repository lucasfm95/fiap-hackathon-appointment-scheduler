namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public class LoginPatientRequest : LoginBaseRequest
{
    public string Email { get; init; }
}