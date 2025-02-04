using Fiap.Hackathon.AppointmentScheduler.Application.Constants;
using Fiap.Hackathon.AppointmentScheduler.Application.Dtos;
using Fiap.Hackathon.AppointmentScheduler.Application.Services;
using Fiap.Hackathon.AppointmentScheduler.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hackathon.AppointmentScheduler.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class PatientController(PatientService patientService) : ControllerBase
{
    [HttpPost()]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] PatientDto patientDto)
    {
        await patientService.CreateAsync(patientDto);
        return Ok();
    }
    
    [HttpGet()]
    [Authorize(Roles = Roles.Doctor)]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await patientService.GetAll());
    }
}