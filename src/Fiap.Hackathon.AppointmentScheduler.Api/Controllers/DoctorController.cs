using Fiap.Hackathon.AppointmentScheduler.Application.Services;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hackathon.AppointmentScheduler.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class DoctorController(DoctorService doctorService) : ControllerBase
{
    [HttpPost()]
    [AllowAnonymous]
    public async Task<IActionResult> Create([FromBody] CreateDoctorRequest createDoctorRequest)
    {
        await doctorService.CreateAsync(createDoctorRequest);
        return Ok();
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await doctorService.GetAll());
    }

    [HttpGet("filtered")]
    public async Task<IActionResult> GetFiltered(string? specialty, string? name, string? crm)
    {
        return Ok(await doctorService.GetFiltered(specialty, name, crm));
    }
}