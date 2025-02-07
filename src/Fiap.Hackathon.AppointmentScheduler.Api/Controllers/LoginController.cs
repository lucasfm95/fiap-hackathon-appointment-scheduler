using Fiap.Hackathon.AppointmentScheduler.Application;
using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Fiap.Hackathon.AppointmentScheduler.Domain.Entities;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hackathon.AppointmentScheduler.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController(AuthTokenService authTokenService, IPatientRepository patientRepository, IDoctorRepository doctorRepository) : ControllerBase
{
    [HttpPost("Patient")]
    public async Task<IActionResult> LoginPatient([FromBody] LoginPatientRequest loginPatient)
    {
        var patient = await GetPatient(loginPatient);

        if (!PasswordHasherHelper.Verify(loginPatient.Password, patient.Password))
        {
            return Unauthorized();
        }
        
        var token = authTokenService.GetToken(patient);

        if (!string.IsNullOrWhiteSpace(token))
        {
            return Ok(token);
        }

        return Unauthorized();
    }

    private  Task<Patient> GetPatient(LoginPatientRequest loginPatient)
    {
        if (loginPatient.Login.All(char.IsDigit) && loginPatient.Login.Length == 11)
        {
            return patientRepository.GetPatientByCpf(loginPatient.Login);
        }
        
        return patientRepository.GetPatientByEmail(loginPatient.Login);
    }

    [HttpPost("Doctor")]
    public async Task<IActionResult> LoginDoctor([FromBody] LoginDoctorRequest loginDoctor)
    {
        var doctor = await doctorRepository.GetDoctorByCrmAsync(loginDoctor.Crm);
        if (!PasswordHasherHelper.Verify(loginDoctor.Password, doctor.Password))
        {
            return Unauthorized();
        }

        var token = authTokenService.GetToken(doctor);

        if (!string.IsNullOrWhiteSpace(token))
        {
            return Ok(token);
        }

        return Unauthorized();
    }
}