using Fiap.Hackathon.AppointmentScheduler.Application.Dtos;
using Fiap.Hackathon.AppointmentScheduler.Application.Services;
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
    public async Task<IActionResult> Create([FromBody] DoctorDto doctorDto)
    {
        await doctorService.CreateAsync(doctorDto);
        return Ok();
    }
    
    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await doctorService.GetAll());
    }
}