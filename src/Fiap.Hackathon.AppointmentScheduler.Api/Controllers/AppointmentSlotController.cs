using Fiap.Hackathon.AppointmentScheduler.Application.Constants;
using Fiap.Hackathon.AppointmentScheduler.Application.Services;
using Fiap.Hackathon.AppointmentScheduler.Domain.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Fiap.Hackathon.AppointmentScheduler.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class AppointmentSlotController(AppointmentSlotService appointmentSlotService): ControllerBase
{
    [HttpPost]
    [Authorize(Roles = Roles.Doctor)]
    public async Task<IActionResult> Create([FromBody] CreateAppointmentSlotRequest createAppointmentSlotRequest)
    {
        await appointmentSlotService.CreateAsync(createAppointmentSlotRequest);
        return Created();
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await appointmentSlotService.GetAll());
    }
    
    [HttpDelete("{id}")]
    [Authorize(Roles = Roles.Doctor)]
    public async Task<IActionResult> Delete([FromRoute]long id)
    {
        await appointmentSlotService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("availableappointment")]
    public async Task<IActionResult> GetAvailableAppointment(int doctorId, DateTime appointmentDate)
    {
        return Ok( await appointmentSlotService.GetAvailableAppointment(doctorId, appointmentDate));
    }
}