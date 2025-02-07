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
        var doctorId = long.Parse(User.Claims.FirstOrDefault(c => c.Type == "DoctorId")!.Value);
        
        await appointmentSlotService.CreateAsync(doctorId, createAppointmentSlotRequest);
        return Created();
    }
    
    [HttpGet]
    [Authorize]
    public async Task<IActionResult> GetAll()
    {
        return Ok(await appointmentSlotService.GetAll());
    }
    
    [HttpDelete("{id:long}")]
    [Authorize(Roles = Roles.Doctor)]
    public async Task<IActionResult> Delete([FromRoute]long id)
    {
        await appointmentSlotService.DeleteAsync(id);
        return Ok();
    }

    [HttpGet("available-appointment")]
    public async Task<IActionResult> GetAvailableAppointment(int doctorId, DateTime appointmentDate)
    {
        return Ok( await appointmentSlotService.GetAvailableAppointment(doctorId, appointmentDate));
    }
}