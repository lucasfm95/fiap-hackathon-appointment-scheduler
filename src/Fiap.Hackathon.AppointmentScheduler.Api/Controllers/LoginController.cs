using Fiap.Hackathon.AppointmentScheduler.Application;
using Fiap.Hackathon.AppointmentScheduler.Application.Dtos;
using Fiap.Hackathon.AppointmentScheduler.Application.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hackathon.AppointmentScheduler.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController(AuthTokenService authTokenService, IPatientRepository patientRepository, IDoctorRepository doctorRepository) : ControllerBase
{
    [HttpPost("Patient")]
    public async Task<IActionResult> LoginPatient([FromBody] LoginPatientDto loginPatient)
    {
        var patient = await patientRepository.GetPatientByEmail(loginPatient.Email);
        
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
    
    [HttpPost("Doctor")]
    public async Task<IActionResult> LoginDoctor([FromBody] LoginDoctorDto loginDoctor)
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