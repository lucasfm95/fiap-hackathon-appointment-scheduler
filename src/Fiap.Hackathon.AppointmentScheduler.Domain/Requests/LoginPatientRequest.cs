namespace Fiap.Hackathon.AppointmentScheduler.Domain.Requests;

public class LoginPatientRequest : LoginBaseRequest
{
    /// <summary>
    /// Can be either the email or the cpf
    /// </summary>
    public string Login { get; set; }
}