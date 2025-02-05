namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public class LoginDoctorRequest : LoginBaseRequest
{
    public string Crm { get; init; }
}